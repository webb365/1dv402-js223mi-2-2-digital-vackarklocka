using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace digital_vackarklocka
{
    class Program
    {
        private static string HorizontalLine = "════════════════════════════════════════════════════════════════════════════════";
       
        static void Main(string[] args)
        {
            ViewTestHeader("Test av standardkonstruktor.",1);
            AlarmClock ac = new AlarmClock();
            Console.WriteLine(ac);

            ViewTestHeader("Test av konstruktorn med två parametrar.", 2);
            ac = new AlarmClock(9, 42);
            Console.WriteLine(ac);

            ViewTestHeader("Test av konstruktorn med fyra parametrar.", 3);
            ac = new AlarmClock(13, 24, 7, 35);
            Console.WriteLine(ac);

            ViewTestHeader("Ställ ett befintligt AlarmClock-objekt till 23:58 och låter den gå 13 minuter.", 4);
            ac = new AlarmClock(23, 58, 7, 35);
            Run(ac, 13);

            ViewTestHeader("Ställer befintligt AlarmClock-objekt till tiden 6:12 och alarmtiden till 6:15 och låter den gå 6 minuter.", 5);
            ac = new AlarmClock(6, 12, 6, 15);
            Run(ac,6);

            ViewTestHeader("Test av egenskaperna så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.", 6);
            try
            {
                ac.Hour = 24;
            }
            catch (Exception ex)
            {
                ViewMessage(ex.Message);
            }
            try
            {
                ac.Minute = 60;
            }
            catch (Exception ex)
            {
                ViewMessage(ex.Message);
            }
            try
            {
                ac.AlarmHour = 24;
            }
            catch (Exception ex)
            {
                ViewMessage(ex.Message);
            }
            try
            {
                ac.AlarmMinute = 60;
            }
            catch (Exception ex)
            {
                ViewMessage(ex.Message);
            }

            ViewTestHeader("Test av konstruktorer så att undantag kastas då tid och alarmtid tilldelas felaktiga värden.", 7);
            try
            {
                ac = new AlarmClock(24, 60);
            }
            catch (Exception ex)
            {
                ViewMessage(ex.Message);
            }
            try
            {
                ac = new AlarmClock(24, 60, 24, 60);
            }
            catch (Exception ex)
            {
                ViewMessage(ex.Message);
            }
        }

        /// <summary>
        /// Kör själva klockan 
        /// </summary>
        /// <param name="ac">Klock objekt ta in</param>
        /// <param name="minutes">Antalet minuter den ska köras</param>
        public static void Run(AlarmClock ac, int minutes)
        {
                   
            ViewMessage(new string[] 
            { 
                " ╔══════════════════════════════════════╗ ",
                " ║       Väckarklockan URLED <TM>       ║ ",
                " ║        Modellnr.:1DV402S2L2B         ║ ",
                " ╚══════════════════════════════════════╝ "
            });

            for (int i = 0; i < minutes; i++)
            {               
                if (ac.TickTock())
                    ViewMessage(ac.ToString() + "BEEP BEEP BEEP! BEEP!", ConsoleColor.Blue);
                else     
                    Console.WriteLine(ac.ToString());
                
            }
        }
        /// <summary>
        /// Visar en header 
        /// uppgraderarad med att den tar in värde för vilket test det är vilket gör att jag kan ta bort första raden
        /// </summary>
        /// <param name="header">texten som ska skrivas ut</param>
        /// <param name="testnum">test nummret</param>
        private static void ViewTestHeader(string header,int testnum)
        {
            if (testnum!=1)
            Console.WriteLine(HorizontalLine);
            Console.WriteLine("Test {1}.\n{0}\n", header, testnum);
        }
        /// <summary>
        /// Vissar meddelande för användaren
        /// </summary>
        /// <param name="message">Medelandet som ska visas</param>
        /// <param name="color">Väljer färg på meddelandet</param>
        private static void ViewMessage(string message, ConsoleColor color = ConsoleColor.Red)
        {
            Console.BackgroundColor = color;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        /// <summary>
        ///  Vissar meddelanden för användaren
        /// </summary>
        /// <param name="messages">En array med alla meddelanden som ska visas</param>
        /// <param name="color">Färgen</param>
        private static void ViewMessage(string[] messages, ConsoleColor color = ConsoleColor.DarkYellow)
        {
            Console.BackgroundColor = color;
            foreach (string i in messages)
            {
                Console.WriteLine(i);
            }
            Console.ResetColor();
        }
        
    }
}
