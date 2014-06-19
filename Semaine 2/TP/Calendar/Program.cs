using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Calendar
{
    class Program
    {
        const string PATH = "d:/data/calendarevents.txt";
        enum MONTH
        {
            january = 1,
            february = 2,
            march = 3,
            april = 4,
            may = 5,
            june = 6,
            july = 7,
            august = 8,
            september = 9,
            october = 10,
            november = 11,
            december = 12
        }

        struct CalendarEvent 
        {
            public string title;
            public DateTime dt;
        }

        static void Main(string[] args)
        {
            run();
            Console.ReadKey();
        }

        static void run()
        {
            CalendarEvent evt = catchEvent();
            try
            {
                saveEvent(evt, PATH);
            }
            catch
            {
                
            }
            DateTime dt = DateTime.Now;
            displayCalendar(dt, dt.daysOff());
            Console.WriteLine();
            displayCalendar(dt.AddMonths(1), dt.AddMonths(1).daysOff());
        }

        static CalendarEvent catchEvent()
        {
            bool first = true;
            CalendarEvent evt;

            do
            {
                Console.Write((!first ? "Error on date format!!! \n" : "") + "Event :");
                evt.title = Console.ReadLine();
                first = false;
            } while ("" == evt.title);

            first = true;
            do
            {
                Console.Write((!first ? "Error on date format!!! \n" :"" ) + "Date of this event (DD/MM/YYYY) :");
                first = false;
            }
            while (!DateTime.TryParse(Console.ReadLine(), out evt.dt));
            return evt;
        }

        static void saveEvent(CalendarEvent evt, string path)
        {
            StreamWriter sr = null;
            try
            {
                sr = File.AppendText(path);
                sr.WriteLine(evt.title + "\n\r" + evt.dt.ToString("dd/mm/yyyy"));
            }
            catch (Exception e)
            {
                throw e;
            }
            finally
            {
                if (null != sr) sr.Close();
            }
        }
        
        static void displayCalendar(DateTime pickedDateTime,DateTime[] daysOff)
        { 
            DateTime dt = new DateTime(pickedDateTime.Year,pickedDateTime.Month,1);
            string title = (MONTH)pickedDateTime.Month + " " + pickedDateTime.Year;
            int week = 0;
            Console.Write(title.PadLeft(title.Length +(24 - title.Length) / 2, ' '));
            writeColumn("------------------------", true);
            writeColumn(ConsoleColor.DarkGray, "", true);
            writeColumn(ConsoleColor.DarkGray, "L");
            writeColumn(ConsoleColor.DarkGray, "M");
            writeColumn(ConsoleColor.DarkGray, "Me");
            writeColumn(ConsoleColor.DarkGray, "J");
            writeColumn(ConsoleColor.DarkGray, "V");
            writeColumn(ConsoleColor.DarkGray, "S");
            writeColumn(ConsoleColor.DarkGray, "D");


            int offsetday = (int)dt.DayOfWeek == 0 ? 7 : (int)dt.DayOfWeek-1;
            int stop = DateTime.DaysInMonth(pickedDateTime.Year, pickedDateTime.Month);

            for (int i = 0; i < stop ; ++i)
            {
                //new line , write number of the week when it s the first day or if we passed sunday (last day of the week)
                if (0==i || 0 == (offsetday + i) % 7)
                    writeColumn(ConsoleColor.DarkGray,(++week).ToString(), true);

                //if we are on the first row , we need to goto to the write column
                if (0 == i)
                    for (int j = 0; j < offsetday ; ++j)
                        writeColumn();

                DateTime curDay = new DateTime(dt.Year,dt.Month,i+1);
                if (curDay.isDayOff())
                    writeColumn(ConsoleColor.Cyan, (i + 1).ToString());
                else if (4 < (offsetday + i ) % 7)
                    writeColumn(ConsoleColor.DarkYellow, (i + 1).ToString());
                else
                    writeColumn((i+1).ToString());
            }
        }

        static void writeColumn(string s="   ", bool skipline = false)
        {
            if (skipline) Console.Write("\n");
            Console.Write(s.PadRight(3, ' '));
        }


        static void writeColumn(ConsoleColor color, string s = "   ", bool skipline = false)
        {
            ConsoleColor tmp = Console.ForegroundColor;
            Console.ForegroundColor = color;
            writeColumn(s, skipline);
            Console.ForegroundColor = tmp;
        }
    }
}
