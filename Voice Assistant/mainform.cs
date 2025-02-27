using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;

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

            RecognitionEngine.SetInputToDefaultAudioDevice();

            string[] textStrings = new[] { "Hi", "Hello", "How are you", "What's your name", "Good morning",
                "Tell me a joke", "Goodbye", "What time is it", "Sing a song",
                "Tell me something interesting", "I love you","Good night","Good evening","Good afternoon",
                "Good evening","Open camera","Open file manager","Open Chrome","Open Firefox",
                "Open Command Prompt","Open CMD"};
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
            }

            try
            {
                RecognitionEngine.RecognizeAsync(RecognizeMode.Multiple);
                isRecognizing = true;
                btnstop.Enabled = true;
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
                    Synthesizer.Speak("I'm your voice assistant");
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
    }
}
