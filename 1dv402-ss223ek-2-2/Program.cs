using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _1dv402_ss223ek_2_2
{
    class Program
    {
        //då metoden ViewTestHeader är oberoende av vilket objekt som skapats
        //så måste de variabler som används i denna också bara bero på klass(static)
        static string HorizontalLine = "===============================================================";

        static void Main(string[] args)
        {
            //test 1
            ViewTestHeader("Test 1.\nTest av standardkonstruktor.\n");
            AlarmClock testClock = new AlarmClock();
            Console.WriteLine(testClock.ToString() + "\n");

            //test 2
            ViewTestHeader("Test 2.\nTest av konstruktor med två parametrar,(9,42).\n");
            testClock = new AlarmClock(9, 42);
            Console.WriteLine(testClock.ToString() + "\n");

            //test 3
            ViewTestHeader("Test 3.\nTest av konstruktor med fyra parametrar,(13,24,7,35).\n");
            testClock = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(testClock.ToString() + "\n");

            //test 4
            ViewTestHeader("Test 4.\nStäller befintligt AlarmClock-objekt till 23:58 och låter det gå 13 minuter\n");
            testClock.Hour = 23;
            testClock.Minute = 58;
            Run(testClock, 13);    //denna testar i sin tur TickTock

            //test 5
            ViewTestHeader("Test 5.\nStäller befintligt AlarmClock-objekt till 6:12 och alarmtiden till 6:15 och låter det gå 6 minuter\n");
            testClock.Hour = 6;
            testClock.Minute = 12;
            testClock.AlarmHour = 6;
            testClock.AlarmMinute = 15;
            Run(testClock, 6);    //denna testar i sin tur TickTock med larm

            //test 6
            ViewTestHeader("Test 6.\nTestar egenskaperna så att undantag kastas då tid och alarmtid tilldelas felaktiga värden\n");

            // inspirerad av test.cs från 2.1, låt felmeddelande genereras vid throw, ta emot här
            try
            {
                testClock.Hour = 36;
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }

            try
            {
                testClock.Minute = 312;
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }

            try
            {
                testClock.AlarmHour = 36;
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }

            try
            {
                testClock.AlarmMinute = 315;
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }

            //test 7
            ViewTestHeader("Test 7.\nTestar konstruktorer så att undantag kastas då tid och alarmtid tilldelas felaktiga värden\n");

            // inspirerad av test.cs från 2.1
            //Måste dela upp detta i fyra fall, annars kommer bara första felet av fyra möjliga 
            // i parameterlistan att hittas med undantagskast från egenskaper
            try
            {
                testClock = new AlarmClock(36, 0, 0, 0);  //fel timme
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }

            try
            {
                testClock = new AlarmClock(0, 300, 0, 0);  //fel minut
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }

            try
            {
                testClock = new AlarmClock(0, 0, 36, 0);  //fel larmTimme
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }

            try
            {
                testClock = new AlarmClock(0, 0, 0, 300);  //fel larmMInute
            }
            catch (Exception ex)
            {
                ViewErrorMessage(ex.Message);
            }



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
            Console.ResetColor();
        }

        private static void ViewTestHeader(string header)
        {
            Console.WriteLine(HorizontalLine);
            Console.WriteLine(header);
        }

    }
}
