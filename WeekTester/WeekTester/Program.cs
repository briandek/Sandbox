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

            Console.WriteLine(dt.Date);
            Console.WriteLine(dt.Month);
            Console.WriteLine(dt.DayOfWeek);
            Console.WriteLine(dt.DayOfYear);

            dt = PrintRestOfMonth(dt);

            for (int i = 0; i < 12; i++)
            {
                dt = PrintRestOfMonth(dt);
            }

        }

        public static DateTime PrintRestOfMonth(DateTime date)
        {
            int monthDays = DateTime.DaysInMonth(date.Year, date.Month);
            int daysInYear = date.DayOfYear;
            int dayInMonth = date.Day;

            Console.WriteLine();
            for (int i = 0; i < (int)date.DayOfWeek; i++)
            {
                Console.Write("   ");
            }
            
            while (dayInMonth <= monthDays)
            {
               
                switch (date.DayOfWeek)
                {
                    case DayOfWeek.Sunday:
                    case DayOfWeek.Monday:
                    case DayOfWeek.Tuesday:
                    case DayOfWeek.Wednesday:
                    case DayOfWeek.Thursday:
                    case DayOfWeek.Friday:
                        Console.Write("{0:00} ", dayInMonth);
                        break;
                    case DayOfWeek.Saturday:
                        Console.WriteLine("{0:00} ", dayInMonth);
                        break;
                    default:
                        break;
                }
                date = date.AddDays(1);
                dayInMonth++;

            }

            return date;

        }
    }
}
