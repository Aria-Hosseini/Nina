﻿using System;
using System.Speech.Recognition;
using System.Speech.Synthesis;
using System.Windows.Forms;

namespace Voice_Assistant
{
    public partial class Form1 : Form
    {
        SpeechRecognitionEngine RecognitionEngine;
        SpeechSynthesizer Synthesizer;
        bool isRecognizing = false; 

        public Form1()
        {
            InitializeComponent();

            RecognitionEngine = new SpeechRecognitionEngine();
            Synthesizer = new SpeechSynthesizer();

            RecognitionEngine.SetInputToDefaultAudioDevice();

            string[] textStrings = new[] { "Hi", "Hello", "How are you", "What's your name", "Good morning",
                "Tell me a joke", "Goodbye", "What time is it", "Sing a song",
                "Tell me something interesting", "I love you"};
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
                MessageBox.Show("Recognition is already in progress.");
                return;
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
                    Synthesizer.Speak("Good morning! How can I help you?");
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
                    Synthesizer.Speak("Did you know honey never spoils? Archaeologists have found pots of honey in ancient Egyptian tombs that are over 3000 years old and still perfectly edible.");
                    break;

                case "I love you":
                    richTextBox1.AppendText($"{Environment.NewLine}I love you");
                    Synthesizer.Speak("Oh wow, that's sweet! I appreciate it.");
                    break;
            }
        }

        private void btnclose_Click(object sender, EventArgs e)
        {
            Application.Exit();
        }

        private void btnminimize_Click(object sender, EventArgs e)
        {
            this.WindowState =(FormWindowState.Minimized);
        }
    }
}
