using System;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.Speech.Synthesis;
using System.Threading;
using System.Linq;
using System.Collections.Generic;
using System.ComponentModel;

namespace VirtualLibrarian.BusinessLogic
{
    public class SpeakingAI
    {
        private SpeechSynthesizer synthesizer = new SpeechSynthesizer();
        private string text = "";
        private bool show = true;
        private bool restart = false;
        public bool run = true;
        private Label lbl;
        private Thread t;
        private readonly object balanceLock = new object();
        public bool SoundEnabled { get; set; }

        //TODO: move UI logic elsewhere
        public AI TextControl { get; set; }

        public SpeakingAI(AI ai,bool soundEnabled = true, int volume = 100,int rate = -2)
        {
            TextControl = ai;
            SoundEnabled = soundEnabled;
            synthesizer.Volume = volume;
            synthesizer.Rate = rate;
        }

        public void TellUser(string msg)
        {
            lbl = TextControl.guideLabel;
            t = new Thread(new ThreadStart(WriteSlowly));
            t.Start();
            text = msg;
            show = true;
            restart = true;
            if (SoundEnabled)
            {
                synthesizer.SpeakAsyncCancelAll();
                synthesizer.SpeakAsync(msg);
            }
        }

        public void WriteSlowly()
        {
            lock (balanceLock)
            {
                while (run)
                {
                    if (show)
                    {
                    replay:
                        Random rnd = new Random();
                        StringBuilder sb = new StringBuilder();
                        foreach (char c in text)
                        {
                            if (restart)
                            {
                                restart = false;
                                goto replay;
                            }
                            sb.Append(c);
                            if (lbl.InvokeRequired)
                            {
                                try
                                {
                                    lbl.Invoke((MethodInvoker)delegate { lbl.Text = sb.ToString(); });
                                }
                                catch (Exception e)
                                {
                                    //throw 
                                }
                            }
                            else
                            {
                                lbl.Text = sb.ToString();
                            }
                            Thread.Sleep(rnd.Next(50, 80));
                        }
                        show = false;
                    }

                }

            }
        }
    }
}
