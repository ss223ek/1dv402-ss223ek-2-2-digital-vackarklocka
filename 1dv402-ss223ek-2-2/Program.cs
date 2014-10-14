using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv402_ss223ek_2_2
{
    class Program
    {
        string HorizontalLine = "===============================================================";
        static void Main(string[] args)
        {
            //test 1
            ViewTestHeader("Test 1.\nTest av standardkonstruktor.\n");
            AlarmClock testClock = new AlarmClock();
            Console.WriteLine(testClock.ToString()+"\n");

            //test 2
            ViewTestHeader("Test 2.\nTest av konstruktor med två parametrar,(9,42).\n");
            testClock = new AlarmClock(9,42);
            Console.WriteLine(testClock.ToString()+"\n");

            //test 3
            ViewTestHeader("Test 3.\nTest av konstruktor med fyra parametrar,(13,24,7,35).\n");
            testClock = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(testClock.ToString() + "\n");

            //test 4
            ViewTestHeader("Test 4.\nStäller befintligt AlarmClock-objekt till 23:58 och låter det gå 13 minuter\n");
            testClock.Hour = 23;
            testClock.Minute = 58;
            Run(testClock,13);    //denna test i sin tur TickTock

            //test 5
            ViewTestHeader("Test 5.\nStäller befintligt AlarmClock-objekt till 6:12 och alarmtiden till 6:15 och låter det gå 6 minuter\n");
            testClock.Hour = 6;
            testClock.Minute = 12;
            testClock.AlarmHour = 6;
            testClock.AlarmMinute = 15;
            Run(testClock, 6);    //denna test i sin tur TickTock med larm



        }

        private static void Run(AlarmClock ac, int minutes)
        {
            for (int i = 0; i < minutes; i++)
            {
                bool alarm = ac.TickTock();
                if (alarm)
                {
                    Console.WriteLine("Beep {0} Beep Beep!", ac.ToString());
                }
                else
                {
                    Console.WriteLine("     {0}", ac.ToString());
                }
            }
        }

        private static void ViewErrorMessage(string message)
        {
            Console.BackgroundColor = ConsoleColor.Red;
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(message);
        }

        private static void ViewTestHeader(string header)
        {
            Console.WriteLine("================================================================");
            Console.WriteLine(header);
        }






    }
}
