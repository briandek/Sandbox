using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeekTester
{
    class Program
    {
        /// <summary>
        /// Messing around with DateTime
        /// </summary>
        /// <param name="args"></param>

        static void Main(string[] args)
        {
            DateTime dt = DateTime.Now;

            PrintWeek(DateTime.Now.AddDays(4));

            for (int i = 0; i < 12; i++)
            {
                dt = PrintMonth(dt);
            }


        }

        public static DateTime PrintWeek(DateTime date)
        {
            while (date.DayOfWeek > DayOfWeek.Sunday)
            {
                date = date.AddDays(-1);
            }

            while (true)
            {
                Console.Write("{0:00} ", date.Day);

                if (date.DayOfWeek == DayOfWeek.Saturday)
                {
                    Console.WriteLine();
                    break;
                }
                
                date = date.AddDays(1);
            }

            return date;
        }

        public static DateTime PrintMonth(DateTime date)
        {
            int monthDays = DateTime.DaysInMonth(date.Year, date.Month);
            int daysInYear = date.DayOfYear;

            Console.WriteLine();

            for (int i = 0; i < (int)date.DayOfWeek; i++)
            {
                Console.Write("   ");
            }

            for (int j = date.Day; j <= monthDays; j++)
            {
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                        Console.Write("{0:00} ", date.Day);
                        break;
                    case DayOfWeek.Saturday:
                        Console.WriteLine("{0:00} ", date.Day);
                        break;
                    default:
                        break;
                }
                date = date.AddDays(1);
            }

            return date;

        }
    }
}
