using System;
using System.Collections.Generic;
using System.Linq;
using System.Speech.Synthesis;
using System.Text;
using System.Threading.Tasks;

namespace VirtualLibrarian.BusinessLogic
{
    public class Speaker 
    {
        public bool SoundEnabled { get; set; }
        public int Volume { get { return synthesizer.Volume; } set { synthesizer.Volume = value; } }
        public int Rate { get { return synthesizer.Rate; } set { synthesizer.Rate = value; } }

        private SpeechSynthesizer synthesizer;

        public Speaker()
        {
            synthesizer = new SpeechSynthesizer();
            SoundEnabled = true;
        }

        public Speaker(int volume, int rate): this()
        {
            Volume = volume;
            Rate = rate;
        }

        public void Speak(string message)
        {
            if (SoundEnabled)
            {
                Task.Run(()=>synthesizer.SpeakAsyncCancelAll());
                Task.Run(()=>synthesizer.SpeakAsync(message));
                
            }
        }
    }
}
