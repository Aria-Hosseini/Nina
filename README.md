# English Version

# Nina - Voice Assistant

**Nina** is a smart voice assistant built with C# and Windows Forms, designed to help you perform everyday tasks using voice commands. From opening apps to searching Google or interacting with custom forms, Nina makes your computer experience hands-free and fun!

---

## ✨ Features

- **Open Applications**: Use commands like "Open Chrome", "Open Telegram", or "Open VS Code" to launch your favorite apps.
- **Simple Conversations**: Responds to greetings, jokes, and questions like "What time is it?".
- **Google Search**: Say "Search weather in Tehran" to search in your default browser.
- **Custom Forms**: Open custom forms like "Open Applist" to view installed programs.
- **Time-Based Responses**: Reacts appropriately to the time of day (morning, afternoon, evening).
- **Voice Customization**: Change Nina’s voice to your preference (e.g., Microsoft Zira or David).

---

## 🛠 Prerequisites

To run or develop Nina, you’ll need:
- **Windows 7/8/10/11** (uses Windows Forms and Speech API)
- **Visual Studio 2019 or later** (for building and debugging)
- **.NET Framework 4.7.2 or higher**
- **Microphone** (for voice command recognition)

---

## 📦 Installation and Setup

1. **Clone the Repository**:
   ```bash
   git clone https://github.com/yourusername/nina-voice-assistant.git
   ```
   (Replace with your repo URL if hosted)

2. **Open the Project**:
   - Open `Voice_Assistant.sln` in Visual Studio.

3. **Build and Run**:
   - Build the project (F5 or Build > Build Solution).
   - Click the "Start" button in the form to begin using Nina!

---

## 🎙 How to Use

After launching, press "Start" to make Nina listen. Try these commands:
- "Hello" → "Hi there!"
- "Open Chrome" → Opens Google Chrome
- "Search best C# tutorials" → Searches Google
- "Open Applist" → Shows a list of installed programs
- "Goodbye" → "Goodbye! Have a great day!"

Click "Stop" to pause listening.

---

## 🖥 User Interface

- **RichTextBox**: Displays your commands and Nina’s responses.
- **Status Label**: Shows "Listening..." in green or "Not Listening" in red.
- **Buttons**: Start, Stop, Minimize, and Close for controlling the assistant.

---

## 🔧 Development and Customization

### Change Voice
To switch Nina’s voice:
1. In `mainform.cs`, in the constructor:
   ```csharp
   Synthesizer.SelectVoice("Microsoft Zira Desktop"); // Or any other voice
   ```
2. To list available voices:
   ```csharp
   foreach (var voice in Synthesizer.GetInstalledVoices())
   {
       MessageBox.Show(voice.VoiceInfo.Name);
   }
   ```

### Add New Commands
1. Add the command to `textStrings` in the constructor (e.g., "Open Notepad").
2. Add a case in `RecognitionEngine_SpeechRecognized`:
   ```csharp
   case "Open Notepad":
       richTextBox1.AppendText($"{Environment.NewLine}Open Notepad");
       Synthesizer.Speak("Opening Notepad...");
       System.Diagnostics.Process.Start("notepad.exe");
       break;
   ```

---

## 🐛 Known Issues

- **App Opening Failures**: If an app’s executable isn’t in PATH, use the full path (e.g., for Telegram).
- **Voice Recognition**: May struggle in noisy environments.

Report any bugs in the Issues section!

---

## 🤝 Contributing

We welcome contributions!
1. Fork the repository.
2. Make changes in a new branch.
3. Submit a Pull Request.

---

## 🙏 Acknowledgments

- Thanks to the C# community for awesome libraries and tools!
- And to you for trying out Nina!

---

Start Nina and enjoy a voice-powered experience! Questions? Hit me up in Issues. 🎤

---

# نسخه فارسی

# نینا - دستیار صوتی



**نینا** یه دستیار صوتی هوشمند ساخته‌شده با C# و Windows Forms هست که بهتون اجازه می‌ده با صدای خودتون کارهای روزمره رو انجام بدید. از باز کردن برنامه‌ها گرفته تا سرچ توی گوگل و تعامل با فرم‌های سفارشی، نینا تجربه کار با کامپیوتر رو بدون دست و جذاب می‌کنه!

---

## ✨ قابلیت‌ها

- **باز کردن برنامه‌ها**: با دستوراتی مثل "Open Chrome"، "Open Telegram" یا "Open VS Code" برنامه‌های مورد علاقه‌تون رو باز کنید.
- **مکالمه ساده**: به سلام‌ها، شوخی‌ها و سؤالاتی مثل "What time is it?" جواب می‌ده.
- **سرچ در گوگل**: بگید "Search weather in Tehran" تا توی مرورگر پیش‌فرض سرچ کنه.
- **فرم‌های سفارشی**: با "Open Applist" لیست برنامه‌های نصب‌شده رو ببینید.
- **پاسخ بر اساس زمان**: به وقت روز (صبح، عصر، شب) جواب مناسب می‌ده.
- **شخصی‌سازی صدا**: صدای نینا رو به دلخواه عوض کنید (مثلاً Microsoft Zira یا David).

---

## 🛠 پیش‌نیازها

برای اجرا یا توسعه نینا، این‌ها رو نیاز دارید:
- **ویندوز 7/8/10/11** (چون از Windows Forms و Speech API استفاده می‌کنه)
- **ویژوال استودیو 2019 یا جدیدتر** (برای بیلد و دیباگ)
- **NET Framework 4.7.2 یا بالاتر**
- **میکروفون** (برای تشخیص دستورات صوتی)

---

## 📦 نصب و راه‌اندازی

1. **مخزن رو کلون کنید**:
   ```bash
   git clone https://github.com/yourusername/nina-voice-assistant.git
   ```
   (اگه پروژه رو توی GitHub داری، آدرسش رو بذار)

2. **پروژه رو باز کنید**:
   - فایل `Voice_Assistant.sln` رو توی ویژوال استودیو باز کنید.

3. **بیلد و اجرا**:
   - پروژه رو بیلد کنید (F5 یا Build > Build Solution).
   - دکمه "شروع" رو توی فرم بزنید تا نینا آماده شنیدن بشه!

---

## 🎙 نحوه استفاده

بعد از اجرا، دکمه "شروع" رو بزنید تا نینا گوش بده. این دستورات رو امتحان کنید:
- "سلام" → "سلام به شما!"
- "Open Chrome" → باز کردن گوگل کروم
- "Search best C# tutorials" → سرچ توی گوگل
- "Open Applist" → نمایش لیست برنامه‌های نصب‌شده
- "خداحافظ" → "خداحافظ! روز خوبی داشته باشید!"

برای توقف، دکمه "توقف" رو بزنید.

---

## 🖥 رابط کاربری

- **RichTextBox**: دستورات شما و جواب‌های نینا رو نشون می‌ده.
- **برچسب وضعیت**: با رنگ سبز ("در حال شنیدن") یا قرمز ("شنیدن متوقف") حالت رو مشخص می‌کنه.
- **دکمه‌ها**: شروع، توقف، کوچک کردن و بستن برای کنترل دستیار.

---

## 🔧 توسعه و شخصی‌سازی

### تغییر صدا
برای عوض کردن صدای نینا:
1. توی `mainform.cs`، توی سازنده:
   ```csharp
   Synthesizer.SelectVoice("Microsoft Zira Desktop"); // یا هر صدای دیگه
   ```
2. برای دیدن صداهای موجود:
   ```csharp
   foreach (var voice in Synthesizer.GetInstalledVoices())
   {
       MessageBox.Show(voice.VoiceInfo.Name);
   }
   ```

### اضافه کردن دستور جدید
1. توی `textStrings` توی سازنده، دستور جدید رو اضافه کنید (مثلاً "Open Notepad").
2. توی `RecognitionEngine_SpeechRecognized` یه کیس جدید بذارید:
   ```csharp
   case "Open Notepad":
       richTextBox1.AppendText($"{Environment.NewLine}Open Notepad");
       Synthesizer.Speak("Opening Notepad...");
       System.Diagnostics.Process.Start("notepad.exe");
       break;
   ```

---

## 🐛 مشکلات شناخته‌شده

- **باز نشدن برخی برنامه‌ها**: اگه مسیر فایل اجرایی توی PATH نباشه، باید مسیر کامل رو بدید (مثلاً برای Telegram).
- **تشخیص صوت**: توی محیط‌های پر سر و صدا ممکنه خطا بده.

اگه مشکلی پیدا کردید، توی بخش Issues بگید!

---

## 🤝 مشارکت

از کمک شما استقبال می‌کنیم!
1. مخزن رو فورک کنید.
2. تغییرات رو توی یه شاخه جدید اعمال کنید.
3. Pull Request بفرستید.

---

## 🙏 تشکر

- از جامعه C# برای ابزارها و کتابخونه‌های عالی!
- و از شما که نینا رو امتحان می‌کنید!

---

نینا رو روشن کنید و از تجربه صوتی لذت ببرید! سؤالی دارید؟ توی Issues بپرسید. 🎤


