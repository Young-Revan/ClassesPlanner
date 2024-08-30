using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarDNF
{
    public struct DayHour
    {
        public int Hours { get; set; }
        public DayOfWeek Day { get; set; }

        public DayHour(DayOfWeek day, int hours)
        {
            Hours = hours;
            Day = day;
        }
    }
}
