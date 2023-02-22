using System;
using System.Speech.Recognition;
using System.Windows.Forms;

namespace TextToSpeech
{
    class Program
    {
        static void Main(string[] args)
        {
            // Der recognizer
            SpeechRecognitionEngine recognizer = new SpeechRecognitionEngine();

            // Hier die Zaubersprüche ändern bzw. ergänzen.
            GrammarBuilder grammarBuilder = new GrammarBuilder();
            string[] words = new string[] { "Incendio", "Protego", "Levioso", "Confringo" };
            grammarBuilder.Append(new Choices(words));

            // Grammatik zuweisen
            Grammar grammar = new Grammar(grammarBuilder);
            recognizer.LoadGrammar(grammar);

            // Hier ein bisschen Code für die Spracheingabe...
            recognizer.SetInputToDefaultAudioDevice();
            recognizer.SpeechRecognized += new EventHandler<SpeechRecognizedEventArgs>(SpeechRecognizedHandler);

            recognizer.RecognizeAsync(RecognizeMode.Multiple);

            Console.ReadKey();
        }

        static void SpeechRecognizedHandler(object sender, SpeechRecognizedEventArgs e)
        {
            // Hier welche Tasten bei welchem Zauberspruch gedrückt werden.
            // Kann auch wahlweise durch if-Anweisungen ausgetauscht werden.
            switch (e.Result.Text)
            {
                case "Protego":
                    SendKeys.SendWait("q");
                    break;
                case "Confringo":
                    SendKeys.SendWait("1");
                    break;
                case "Levioso":
                    SendKeys.SendWait("2");
                    break;
                case "Incendio":
                    SendKeys.SendWait("3");
                    break;
                default:
                    break;
            }
            Console.WriteLine("Erkannt: " + e.Result.Text);
        }
    }
}
