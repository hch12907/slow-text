using System;
using System.Timers;

namespace SlowText
{
    class SlowText
    {
        Timer timer;
        public string text { get; private set; }
        public int interval { get; private set; }
        public int wait { get; private set; }

        private int counter;

        /// <summary>
        /// The constructor of SlowText. The first param is the text you
        /// want to show slowly, the second param is the interval between
        /// each char, the third param is how long SlowText waits after
        /// finishing its job.
        /// </summary>
        /// <param name="Text"></param>
        /// <param name="Interval"></param>
        /// <param name="Wait"></param>
        public SlowText(string text, int interval = 1000, int wait = 0)
        {
            this.text = text;
            this.interval = interval;
            this.wait = wait;
        }

        /// <summary>
        /// The method to start SlowText.
        /// </summary>
        public void Start()
        {
            timer = new Timer();
            timer.Interval = interval;
            timer.Elapsed += (x, y) => { UpdateString(); };
            timer.Start();
            Sleep();
        }

        /// <summary>
        /// It actually doesn't update the string, but
        /// instead print it. It actually updates another string 
        /// in the original code. Oh well, I was too lazy to change
        /// the name to another name that makes sense. ¯\_(ツ)_/¯
        /// </summary>
        void UpdateString()
        {
            if(text.Length > counter)
                PrintText(text[counter++]);
            else
                timer.Stop();
        }

        /// <summary>
        /// You can override this if you want to use other sleeping method.
        /// 
        /// </summary>
        public virtual void Sleep()
        {
            System.Threading.Thread.Sleep(interval * text.Length + wait);
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
