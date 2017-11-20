using System;
using System.Timers;

namespace SlowText
{
    class SlowText
    {
        Timer timer;
        public string Text { get; private set; }
        public int Interval { get; private set; }
        public int Wait { get; private set; }

        private int counter;

        /// <summary>
        /// The constructor of SlowText. The first param is the text you
        /// want to print slowly, the second param is the time interval
        /// between each char, the third param is how long SlowText waits
        /// after finishing its job.
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Interval"></param>
        /// <param name="Wait"></param>
        public SlowText(string text, int interval = 1000, int wait = 0)
        {
            this.Text = text;
            this.Interval = interval;
            this.Wait = wait;
        }

        /// <summary>
        /// Start SlowText.
        /// </summary>
        public void Start()
        {
            timer = new Timer();
            timer.Interval = Interval;
            timer.Elapsed += (x, y) => { Print(); };
            timer.Start();
            Sleep();
        }

        /// <summary>
        /// Prints the text slowly.
        /// </summary>
        void Print()
        {
            if(Text.Length > counter)
                PrintText(Text[counter++]);
            else
                timer.Stop();
        }

        /// <summary>
        /// You can override this if you want to use other sleeping method.
        /// 
        /// </summary>
        public virtual void Sleep()
        {
            System.Threading.Thread.Sleep(Interval * Text.Length + Wait);
        }

        /// <summary>
        /// You can override this if you want it to use other method to print the text/char.
        /// Default uses Console.Write().
        /// </summary>
        /// <param name="text"></param>
        public virtual void PrintText(char text)
        {
            Console.Write(text);
        }
    }
}
