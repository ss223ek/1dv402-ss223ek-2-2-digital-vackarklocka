using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv402_ss223ek_2_2
{
    public class AlarmClock
    {
        private int _alarmHour;
        private int _alarmMinute;
        private int _hour;
        private int _minute;

        public int AlarmHour
        {
            get { return _alarmHour; }
            set
            {
                if (value < 0 || value > 23)
                {
                    throw new ArgumentException("Alarmtimmen är inte i intervallet 0-23");
                }
                _alarmHour = value;
            }
        }

        public int AlarmMinute
        {
            get { return _alarmMinute; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Alarmminuten är inte i intervallet 0-59");
                }
                _alarmMinute = value;
            }
        }

        public int Hour
        {
            get { return _hour; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Timmen är inte i intervallet 0-23");
                }
                _hour = value;
            }
        }

        public int Minute
        {
            get { return _minute; }
            set
            {
                if (value < 0 || value > 59)
                {
                    throw new ArgumentException("Minuten är inte i intervallet 0-59");
                }
                _minute = value;
            }
        }

        //default, skickar grnudtid och grundalarm till nästa
        public AlarmClock()
            : this(0, 0)
        { }

        //nästa konstr. tar emot två värden och skickar med grundalarm
        public AlarmClock(int hour, int minute)
            : this(hour, minute, 0, 0)
        { }

        //den konstruktor som genomförs har alla värden nu.
        //tester av värden sker i egenskaper
        public AlarmClock(int hour, int minute, int alarmHour, int alarmMinute)
        {
            Hour = hour;
            Minute = minute;
            AlarmHour = alarmHour;
            AlarmMinute = alarmMinute;

        }

        public bool TickTock()
        {
            // kolla om det går att addera en minut utan att slå över
            if (Minute < 59)
            {
                Minute += 1;
            }
            // överslag har skett
            else
            {
                Minute = 0;

                // kolla om det går att addera en timme utan överslag
                if (Hour < 23)
                {
                    Hour += 1;
                }
                else
                {
                    Hour = 0;
                }
            }

            //nu har vi den nya tiden, är det dags att larma?


            return false;
        }



    }
}
