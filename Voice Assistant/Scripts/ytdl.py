import tkinter as tk
from tkinter.filedialog import askdirectory
from tkinter import messagebox
import yt_dlp
import os

window = tk.Tk()
window.title("YouTube Downloader")
window.geometry("400x200")
window.resizable(False, False)

def widgets():
    link_lable = tk.Label(window, text="لینک ویدیو:")
    link_lable.grid(row=0 , padx=10 , pady= 10)

    link_entry = tk.Entry(window, width=30,textvariable=download_link)
    link_entry.grid(row=0, column=1 )

    lable_dir = tk.Label(window,text="مسیر دریافت ویدیو:")
    lable_dir.grid(row=1 , column=0)

    dir_entry = tk.Entry(window, width=30, textvariable = download_dir)
    dir_entry.grid(row= 1 ,column=1)

    btn_dir = tk.Button(window,text="انتخاب مسیر",bg="medium aquamarine",fg="black",command=browse)
    btn_dir.grid(row=1, column=2)

    btn_dl = tk.Button(window,text="دانلود",width=5,pady=10,padx=20,bg="tomato3",command=download_video)
    btn_dl.grid(row=2,column=1,pady=40)

def browse():
    directory = askdirectory(title="save in")
    if directory:
        download_dir.set(directory)

def download_video():
    try:
        link = download_link.get().strip()
        save_dir = download_dir.get().strip()

        if not link:
            messagebox.showerror("خطا", "لطفاً لینک ویدیو را وارد کنید")
            return
        if not save_dir or not os.path.exists(save_dir):
            messagebox.showerror("خطا", "لطفاً یک مسیر معتبر انتخاب کنید")
            return

        ydl_opts = {
            'format': 'best[ext=mp4]', 
            'outtmpl': os.path.join(save_dir, '%(title)s.%(ext)s'),
            'noplaylist': True,
            'cookiefile': './cookies.txt',  
        }

        with yt_dlp.YoutubeDL(ydl_opts) as ydl:
            ydl.download([link])

        messagebox.showinfo(title="success",message="ویدیو مورد نظر شما با موفقیت دانلود شد")
    except Exception as e:
        error_msg = str(e)
        if "Sign in" in error_msg or "bot" in error_msg:
            messagebox.showerror("خطا", "این ویدیو نیاز به ورود دارد. لطفاً فایل کوکی را بررسی کنید.")
        else:
            messagebox.showerror("خطا", f"خطا: {error_msg}")

download_link = tk.StringVar()
download_dir = tk.StringVar()

widgets()
window.mainloop()