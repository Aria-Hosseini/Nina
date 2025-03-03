using System;
using System.Diagnostics;
using System.Drawing;
using System.IO;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;
using AForge.Video;
using AForge.Video.DirectShow;
using InstalledPrograms;

namespace Voice_Assistant
{
    public partial class mainform : Form
    {
        SpeechRecognitionEngine RecognitionEngine;
        SpeechSynthesizer Synthesizer;
        bool isRecognizing = false;

        public mainform()
        {
            InitializeComponent();

            RecognitionEngine = new SpeechRecognitionEngine();
            Synthesizer = new SpeechSynthesizer();
            Synthesizer.SelectVoice("Microsoft Zira Desktop");
            RecognitionEngine.SetInputToDefaultAudioDevice();


            string[] textStrings = new[] { "Hi", "Hello", "How are you", "What's your name", "Good morning",
                "Tell me a joke", "Goodbye", "What time is it", "Sing a song",
                "Tell me something interesting", "I love you","Good night","Good evening","Good afternoon",
                "Good evening","Open camera","Open file manager","Open Chrome","Open Firefox",
                "Open Command Prompt","Open CMD","Who are you","Open calculator","Open calcu","Open Edge",
                "Open email","Open start","Open Word","Open PowerPoint","Open Excel","Open VS Code",
                "Open Visual Studio","Take a picture","Open apps","Open telegram","Thank you","YouTube downloader"};
            Choices choices = new Choices(textStrings);
            GrammarBuilder grammarBuilder = new GrammarBuilder(choices);
            Grammar grammar = new Grammar(grammarBuilder);
            RecognitionEngine.LoadGrammarAsync(grammar);

            RecognitionEngine.SpeechRecognized += RecognitionEngine_SpeechRecognized;
        }

        private void btnstart_Click(object sender, EventArgs e)
        {
            if (isRecognizing)
            {
                RecognitionEngine.RecognizeAsyncStop();
                isRecognizing = false;
                lblStatus.Text = "Not Listening";
                lblStatus.ForeColor = Color.Red;
                return;
            }

            try
            {
                RecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
                isRecognizing = true;
                btnstop.Enabled = true;
                lblStatus.Text = "listening...";
                lblStatus.ForeColor = Color.Green;
            }
            catch (InvalidOperationException ex)
            {
                MessageBox.Show($"Error: {ex.Message}");
            }
        }

        private void btnstop_Click(object sender, EventArgs e)
        {
            if (isRecognizing)
            {
                RecognitionEngine.RecognizeAsyncStop();
                isRecognizing = false;
                btnstop.Enabled = false;
                lblStatus.Text = "Not Listening";
                lblStatus.ForeColor = Color.Red;
            }
        }

        private void RecognitionEngine_SpeechRecognized(object sender, SpeechRecognizedEventArgs e)
        {
            string text = e.Result.Text;
            switch (text)
            {
                //مکالمه با ربات
                case "Hi":
                    richTextBox1.AppendText($"{Environment.NewLine}Hi");
                    Synthesizer.Speak("Hello");
                    break;
                case "Hello":
                    richTextBox1.AppendText($"{Environment.NewLine}Hello");
                    Synthesizer.Speak("Hi there!");
                    break;
                case "How are you":
                    richTextBox1.AppendText($"{Environment.NewLine}How are you");
                    Synthesizer.Speak("I'm fine, thank you!");
                    break;
                case "What's your name":
                    richTextBox1.AppendText($"{Environment.NewLine}What's your name");
                    Synthesizer.Speak("I'm Nina, your voice assistant");
                    break;
                case "Who are you":
                    richTextBox1.AppendText($"{Environment.NewLine}Who are you");
                    Synthesizer.Speak("I'm Nina, your voice assistant");
                    break;
                case "Thank you":
                    richTextBox1.AppendText($"{Environment.NewLine}Thank you");
                    Synthesizer.Speak("Your welcome.");
                    break;
                case "Good morning":
                    richTextBox1.AppendText($"{Environment.NewLine}Good morning");

                    int currentHour = DateTime.Now.Hour;

                    if (currentHour >= 5 && currentHour < 12)
                    {
                        Synthesizer.Speak("Good morning! Hope you have a fantastic day!");
                    }
                    else
                    {
                        Synthesizer.Speak("It's not morning right now, but I hope you're having a great time!");
                    }
                    break;
                case "Tell me a joke":
                    richTextBox1.AppendText($"{Environment.NewLine}Tell me a joke");
                    Synthesizer.Speak("Why did the tomato turn red? Because it saw the salad dressing!");
                    break;
                case "Goodbye":
                    richTextBox1.AppendText($"{Environment.NewLine}Goodbye");
                    Synthesizer.Speak("Goodbye! Have a great day!");
                    break;

                case "What time is it":
                    richTextBox1.AppendText($"{Environment.NewLine}What time is it");
                    Synthesizer.Speak($"The time is {DateTime.Now.ToShortTimeString()}.");
                    break;

                case "Sing a song":
                    richTextBox1.AppendText($"{Environment.NewLine}Sing a song");
                    Synthesizer.Speak("La la la... I hope you enjoyed my song!");
                    break;

                case "Tell me something interesting":
                    richTextBox1.AppendText($"{Environment.NewLine}Tell me something interesting");

                    string[] interestingFacts = new string[]
                    {
                        "Did you know honey never spoils? Archaeologists have found pots of honey in ancient Egyptian tombs that are over 3000 years old and still perfectly edible.",
                        "A group of flamingos is called a 'flamboyance'.",
                        "Bananas are berries, but strawberries aren't.",
                        "Did you know octopuses have three hearts and blue blood?",
                        "A small child could swim through the veins of a blue whale, it's that big!",
                        "The Eiffel Tower can grow by up to 6 inches during the summer due to the expansion of iron in the heat.",
                        "Some turtles can breathe through their butts!"
                    };

                    Random rand = new Random();
                    string randomFact = interestingFacts[rand.Next(interestingFacts.Length)];

                    Synthesizer.Speak(randomFact);
                    break;

                case "I love you":
                    richTextBox1.AppendText($"{Environment.NewLine}I love you");
                    Synthesizer.Speak("Oh wow, that's sweet! I appreciate it.");
                    break;
                case "Good afternoon":
                    richTextBox1.AppendText($"{Environment.NewLine}Good afternoon");
                    int currentHoura = DateTime.Now.Hour;

                    if (currentHoura >= 12 && currentHoura < 16)
                    {
                        Synthesizer.Speak("Good afternoon! How can I help you?");
                    }
                    else
                    {
                        Synthesizer.Speak("It's not afternoon right now, but I hope you're having a great time!");
                    }
                    break;
                case "Good evening":
                    richTextBox1.AppendText($"{Environment.NewLine}Good evening");
                    int currentHoure = DateTime.Now.Hour;

                    if (currentHoure >= 16 && currentHoure < 18)
                    {
                        Synthesizer.Speak("Good evening! What can I do for you?");
                    }
                    else
                    {
                        Synthesizer.Speak("It's not evening right now, but I hope you're having a great time!");
                    }
                    break;
                case "Good night":
                    richTextBox1.AppendText($"{Environment.NewLine}Good night");
                    int currentHourn = DateTime.Now.Hour;

                    if (currentHourn >= 18 && currentHourn < 24)
                    {
                        Synthesizer.Speak("Good night! What can I do for you?");
                    }
                    else
                    {
                        Synthesizer.Speak("It's not night right now, but I hope you're having a great time!");
                    }
                    break;
                //بازکردن برنامه ها
                case "Open camera":
                    richTextBox1.AppendText($"{Environment.NewLine}Open camera");
                    Synthesizer.Speak("Opening camera...");

                    try
                    {
                        System.Diagnostics.Process.Start("microsoft.windows.camera:");
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open the camera.");
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    break;
                case "Take a picture":
                    richTextBox1.AppendText($"{Environment.NewLine}Take a picture");
                    Synthesizer.Speak("Taking a picture...");
                    try
                    {
                        var videoDevices = new FilterInfoCollection(FilterCategory.VideoInputDevice);
                        if (videoDevices.Count == 0)
                        {
                            Synthesizer.Speak("No camera found.");
                            MessageBox.Show("No camera device detected.");
                            return;
                        }

                        var videoSource = new VideoCaptureDevice(videoDevices[0].MonikerString);
                        videoSource.NewFrame += (s, ev) =>
                        {
                            Bitmap image = (Bitmap)ev.Frame.Clone();
                            string savePath = $@"C:\Users\<Username>\Pictures\Photo_{DateTime.Now.ToString("yyyyMMdd_HHmmss")}.jpg";
                            image.Save(savePath);
                            Synthesizer.Speak("Picture saved.");
                            videoSource.SignalToStop(); 
                        };
                        videoSource.Start();
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't take a picture.");
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    break;
                case "Open file manager":
                    richTextBox1.AppendText($"{Environment.NewLine}Open file manager");
                    Synthesizer.Speak("Opening file manager...");

                    try
                    {
                        System.Diagnostics.Process.Start("explorer.exe");
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open the file manager.");
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    break;
                case "Open Chrome":
                    richTextBox1.AppendText($"{Environment.NewLine}Opening Chrome");
                    Synthesizer.Speak("Opening Google Chrome...");

                    try
                    {
                        System.Diagnostics.Process.Start("chrome.exe");
                    }
                    catch (Exception)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open Chrome.");
                    }
                    break;
                case "Open Firefox":
                    richTextBox1.AppendText($"{Environment.NewLine}Opening Firefox");
                    Synthesizer.Speak("Opening Mozilla Firefox...");

                    try
                    {
                        System.Diagnostics.Process.Start("firefox.exe");
                    }
                    catch (Exception)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open Firefox.");
                    }
                    break;
                case "Open Command Prompt":
                case "Open CMD":
                    richTextBox1.AppendText($"{Environment.NewLine}Opening Command Prompt");
                    Synthesizer.Speak("Opening Command Prompt...");

                    try
                    {
                        System.Diagnostics.Process.Start("cmd.exe");
                    }
                    catch (Exception)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open Command Prompt.");
                    }
                    break;
                case "Open calculator":
                case "Open calcu":
                    richTextBox1.AppendText($"{Environment.NewLine}Open calculator");
                    Synthesizer.Speak("Opening calculator...");

                    try
                    {
                        System.Diagnostics.Process.Start("calc.exe");
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open the calculator.");
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    break;
                case "Open Edge":
                    richTextBox1.AppendText($"{Environment.NewLine}Open Edge");
                    Synthesizer.Speak("Opening Microsoft Edge...");
                    try
                    {
                        System.Diagnostics.Process.Start("msedge.exe");
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open Edge.");
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    break;
                case "Open email":
                    richTextBox1.AppendText($"{Environment.NewLine}Open email");
                    Synthesizer.Speak("Opening your email...");
                    try
                    {
                        System.Diagnostics.Process.Start("mailto:");
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open the email app.");
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    break;
                case "Open start":
                    richTextBox1.AppendText($"{Environment.NewLine}Open start");
                    Synthesizer.Speak("Opening the start menu...");
                    try
                    {
                        SendKeys.SendWait("{ESC}");
                        SendKeys.SendWait("^{ESC}");
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open the start menu.");
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    break;
                case "Open Word":
                    richTextBox1.AppendText($"{Environment.NewLine}Open Word");
                    Synthesizer.Speak("Opening Microsoft Word...");

                    try
                    {
                        System.Diagnostics.Process.Start("winword.exe");
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open Word.");
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    break;
                case "Open PowerPoint":
                    richTextBox1.AppendText($"{Environment.NewLine}Open PowerPoint");
                    Synthesizer.Speak("Opening Microsoft PowerPoint...");

                    try
                    {
                        System.Diagnostics.Process.Start("powerpnt.exe");
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open PowerPoint.");
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    break;
                case "Open Excel":
                    richTextBox1.AppendText($"{Environment.NewLine}Open Excel");
                    Synthesizer.Speak("Opening Microsoft Excel...");

                    try
                    {
                        System.Diagnostics.Process.Start("excel.exe");
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open Excel.");
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    break;
                case "Open VS Code":
                    richTextBox1.AppendText($"{Environment.NewLine}Open VS Code");
                    Synthesizer.Speak("Opening Visual Studio Code...");

                    try
                    {
                        System.Diagnostics.Process.Start("Code.exe");
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open VS Code.");
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    break;
                case "Open Visual Studio":
                    richTextBox1.AppendText($"{Environment.NewLine}Open Visual Studio");
                    Synthesizer.Speak("Opening Visual Studio...");

                    try
                    {
                        System.Diagnostics.Process.Start("devenv.exe");
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open Visual Studio.");
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    break;
                case "Open telegram":
                    richTextBox1.AppendText($"{Environment.NewLine}Open telegram");
                    Synthesizer.Speak("Opening telegram...");
                    try
                    {
                        string telegramPath = @"C:\Users\<Username>\AppData\Roaming\Telegram Desktop\Telegram.exe";
                        System.Diagnostics.Process.Start(telegramPath); 
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open telegram.");
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    break;
                //انجام عملیات
                case "Open apps":
                    richTextBox1.AppendText($"{Environment.NewLine}Open apps");
                    Synthesizer.Speak("Opening the app list ...");
                    try
                    {
                        Form1 applistForm = new Form1(); 
                        applistForm.Show(); 
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't open the app list .");
                        MessageBox.Show($"Error: {ex.Message}");
                    }
                    break;
                case "YouTube downloader":
                    richTextBox1.AppendText($"{Environment.NewLine}YouTube downloader");
                    Synthesizer.Speak("Running YouTube downloader...");
                    try
                    {
                        string pythonPath = @"C:\Users\Markazi.co\AppData\Local\Programs\Python\Python312\python.exe"; // مسیر Python رو درست کن
                        string scriptPath = Path.Combine(Application.StartupPath, "Scripts", "ytdl.py"); 

                        // چک کردن وجود فایل‌ها
                        if (!File.Exists(pythonPath))
                        {
                            Synthesizer.Speak("Python interpreter not found.");
                            MessageBox.Show($"Python not found at: {pythonPath}");
                            return;
                        }

                        if (!File.Exists(scriptPath))
                        {
                            Synthesizer.Speak("YouTube downloader script not found.");
                            MessageBox.Show($"Script not found at: {scriptPath}");
                            return;
                        }

                        ProcessStartInfo startInfo = new ProcessStartInfo
                        {
                            FileName = pythonPath,
                            Arguments = $"\"{scriptPath}\"",
                            RedirectStandardOutput = true,
                            RedirectStandardError = true,
                            UseShellExecute = false,
                            CreateNoWindow = true
                        };

                        using (Process process = new Process { StartInfo = startInfo })
                        {
                            process.Start();
                            string output = process.StandardOutput.ReadToEnd();
                            string error = process.StandardError.ReadToEnd();
                            process.WaitForExit();

                            if (!string.IsNullOrEmpty(error))
                            {
                                Synthesizer.Speak("Sorry, there was an error running the YouTube downloader.");
                                MessageBox.Show($"Python Error: {error}");
                            }
                            else if (string.IsNullOrEmpty(output))
                            {
                                Synthesizer.Speak("YouTube downloader ran as your commad.");
                                richTextBox1.AppendText($"{Environment.NewLine}No output from script.");
                            }
                            else
                            {
                                Synthesizer.Speak("YouTube downloader finished. Check the output.");
                                richTextBox1.AppendText($"{Environment.NewLine}Output: {output.Trim()}");
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        Synthesizer.Speak("Sorry, I couldn't run the YouTube downloader.");
                        MessageBox.Show($"C# Error: {ex.Message}");
                    }
                    break;


            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState = (FormWindowState.Minimized);
        }

        private void button1_Click(object sender, EventArgs e)
        {
            this.WindowState = (FormWindowState.Minimized);

        }
    }
}
