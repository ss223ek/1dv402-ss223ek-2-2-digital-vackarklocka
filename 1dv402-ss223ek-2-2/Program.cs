using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv402_ss223ek_2_2
{
    class Program
    {
        //string HorizontalLine = "===============================================================";
        static void Main(string[] args)
        {
            //skapa objekt
            AlarmClock testClock = new AlarmClock();

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
