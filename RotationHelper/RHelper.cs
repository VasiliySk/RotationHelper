using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Timers;
using static RotationHelper.frmMain;

namespace RotationHelper
{
    class RHelper
    {
        public ActionEnum action { get; set; }
        public String value { get; set; }
        Timer _timer;
        public int initCountDown { get; set; }
        int countDown;
        String skip;
        public Boolean keyAction { get; set; }

        public RHelper(ActionEnum action, String value, int countDown, String skip)
        {
            this.action = action;
            this.value = value;            
            this.initCountDown = countDown;
            keyAction = true;
            _timer = new Timer();
            _timer.Elapsed += new ElapsedEventHandler(DisplayTimeEvent);
            _timer.Interval = 100;
        }

        public void Start()
        {
            _timer.Start();
            Console.WriteLine("Таймер стартовал!");
            countDown = 0;
            keyAction = false;
        }

        public void Stop()
        {
            _timer.Stop();
        }

        public void DisplayTimeEvent(object source, ElapsedEventArgs e)
        {            
            countDown = countDown + 100;            
            if (countDown > initCountDown)
            {
                keyAction = true;
            }
            
        }

    }
}
