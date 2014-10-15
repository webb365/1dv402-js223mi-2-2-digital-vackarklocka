using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digital_vackarklocka
{
    class ClockDisplay
    {
        private NumberDisplay _hourDisplay;

        private NumberDisplay _minuteDisplay;


        public ClockDisplay()
            : this(0, 0)
        {

        }
        public ClockDisplay(int hour, int minute)
        {

            _hourDisplay = new NumberDisplay(23, hour);
            _minuteDisplay = new NumberDisplay(59, minute);

        }

        public void Increment()
        {
            _minuteDisplay.Increment();
            if (_minuteDisplay.Number == 0)
                _hourDisplay.Increment();
        }
        public override string ToString()
        {

            DateTime time = new DateTime(1, 1, 1, Hour, Minute, 1, 1);
            return string.Format("{0:HH:mm}", time);

        }
        public int Hour
        {
            get 
            { 
                return _hourDisplay.Number; 
            }
            set
            {
                _hourDisplay.Number = value;
            }
        }
        public int Minute
        {
            get 
            { 
                return _minuteDisplay.Number;
            }
            set
            {
                _minuteDisplay.Number = value;
            }
        }
    }
}
