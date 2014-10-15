using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace digital_vackarklocka
{
    class AlarmClock
    {   
        private ClockDisplay _time;
        private ClockDisplay _alarmTime;
        public int AlarmHour
        {

            get
            {
                return _alarmTime.Hour;
            }

            set
            {
                _alarmTime.Hour = value;
            }
        }
        public int AlarmMinute
        {
            get
            {
                return _alarmTime.Minute;
            }

            set
            {
                _alarmTime.Minute = value;
            }

        }
        public int Hour
        {
            get
            {
                return _time.Hour;
            }

            set
            {
                _time.Hour = value;
            }
        }
        public int Minute
        {
            get
            {
                return _time.Minute;
            }

            set
            {
                _time.Minute = value;
            }

        }
        public AlarmClock() : this(0, 0) { }
        public AlarmClock(int hour, int minute) : this(hour, minute, 0, 0) { }
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            _time = new ClockDisplay();
            _alarmTime = new ClockDisplay();
            Hour = hour;
            Minute = minute;
            AlarmHour = alarmHour;
            AlarmMinute = alarmMinute;
        }
        /// <summary>
        /// Ökar en minut
        /// </summary>
        /// <returns>Ifall larmet ska köras</returns>
        public bool TickTock()
        {
            _time.Increment();
            if (Minute == AlarmMinute && Hour == AlarmHour)
                return true;
            else
                return false;
        }
        /// <summary>
        /// Omvandlas till text sträng 
        /// </summary>
        /// <returns>Textstängen retuneras </returns>
        public override string ToString()
        {
            return string.Format("{0} ({1})", _time, _alarmTime);
        }
   

    }
}

