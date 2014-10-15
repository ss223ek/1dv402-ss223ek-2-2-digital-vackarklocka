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
                if (value < 0 || value > 23)
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
            return (Hour==AlarmHour && Minute==AlarmMinute);
        }

        public override string ToString()   //skapar ny innebörd för ToString för alla AlarmClock-objekt
        {
            string h, m, ah, am, total;
            h = Hour.ToString();        //använder den ToString-metod som gäller för INT
            m = Minute.ToString("00");  //håller två platser, fyller ev med inledande nolla
            ah = AlarmHour.ToString();
            am = AlarmMinute.ToString("00");
            total = String.Format("{0,2}:{1} ({2}:{3})", h, m, ah, am); 
            return total;
        }

        //Skrivet innan jag såg föreläsning 12
        // går det lika bra att bara använda samma namn för att "override"
        // Fråga Annie


        //public string ToString() 
        //{
        //    // håller en plats med nollor i minuter så det alltid är två tecken
        //    // timmar kan bli ental till ett tecken
        //    // slår samman efter typomvandling
        //    //http://msdn.microsoft.com/en-us/library/0c899ak8%28v=vs.110%29.aspx#Specifier0
        //    string h, m, ah, am, total;
        //    h = Hour.ToString();
        //    m = Minute.ToString("00");
        //    ah = AlarmHour.ToString();
        //    am=AlarmMinute.ToString("00");
        //    total=String.Format("{0,2}:{1} ({2}:{3})",h,m,ah,am); // högerjustera med två platser för timme
        //    return total;
        //}


    }
}
