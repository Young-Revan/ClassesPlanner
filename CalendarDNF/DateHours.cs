using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CalendarDNF
{
    public struct DateHours
    {
        public DateTime Date { get; set; }
        public int Hours { get; set; }

        public DateHours(DateTime date, int hours)
        {
            Date = date;
            Hours = hours;
        }
    }
}
