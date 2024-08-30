using System;
using System.Collections.Generic;
using System.IO;
using System.Text.Json;

namespace CalendarDNF
{
    public class DatesHandler
    {
        DateTime begining;
        DateTime ending;
        int hoursCount;
        List<DayHour> days;
        List<DateTime> holidays;

        public DateTime Begining { get => begining; set => begining = value; }
        public DateTime Ending { get => ending; set => ending = value; }
        public int HoursCount { get => hoursCount; set => hoursCount = value; }
        public List<DateTime> Holidays { get => holidays; set => holidays = value; }

        public List<DayHour> Days { get => days; set => days = value; }

        public DatesHandler()
        {
            begining = DateTime.Now;
            ending = DateTime.Now;
            hoursCount = 0;
            days = new List<DayHour>();

            holidays = new List<DateTime>();

            if(File.Exists(Directory.GetCurrentDirectory() + "holidays.json"))
            {
                LoadHolidays();
            }

            //holidays.Add(new DateTime(DateTime.Now.Year, 11, 4));

            //holidays.Add(new DateTime(DateTime.Now.Year, 12, 31));
            //holidays.Add(new DateTime(DateTime.Now.Year, 1, 1));
            //holidays.Add(new DateTime(DateTime.Now.Year, 1, 2));
            //holidays.Add(new DateTime(DateTime.Now.Year, 1, 3));
            //holidays.Add(new DateTime(DateTime.Now.Year, 1, 4));
            //holidays.Add(new DateTime(DateTime.Now.Year, 1, 5));
            //holidays.Add(new DateTime(DateTime.Now.Year, 1, 6));
            //holidays.Add(new DateTime(DateTime.Now.Year, 1, 7));
            //holidays.Add(new DateTime(DateTime.Now.Year, 1, 8));

            //holidays.Add(new DateTime(DateTime.Now.Year, 2, 23));
            //holidays.Add(new DateTime(DateTime.Now.Year, 3, 8));

            //holidays.Add(new DateTime(DateTime.Now.Year, 5, 1));
            //holidays.Add(new DateTime(DateTime.Now.Year, 5, 9));
            //holidays.Add(new DateTime(DateTime.Now.Year, 5, 10));
        }

        public List<DateHours> Process()
        {
            List<DateHours> datesList = new List<DateHours>();

            DateTime current = begining;
            int hours = 0;
            while (current <= ending && hours < hoursCount)
            {
                bool isHoliday = false;
                foreach(DateTime holiday in holidays)
                {
                    if (current.Day == holiday.Day && current.Month == holiday.Month)
                    {
                        isHoliday = true;
                        break;
                    }
                }

                if (isHoliday)
                {
                    current = current.AddDays(1);
                    continue;
                }
                
                foreach(DayHour day in days)
                {
                    if (current.DayOfWeek == day.Day)
                    {
                        datesList.Add(new DateHours(current, day.Hours));
                        hours += day.Hours;
                    }
                }
                
                current = current.AddDays(1);
            }

            return datesList;
        }

        async public void LoadHolidays()
        {
            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "holidays.json", FileMode.OpenOrCreate))
            {
                holidays = await JsonSerializer.DeserializeAsync<List<DateTime>>(fs);
            }
        }

        async public void SaveHolidays()
        {
            if (File.Exists(Directory.GetCurrentDirectory() + "holidays.json"))
            {
                File.Delete(Directory.GetCurrentDirectory() + "holidays.json");
            }
            using (FileStream fs = new FileStream(Directory.GetCurrentDirectory() + "holidays.json", FileMode.OpenOrCreate))
            {
                await JsonSerializer.SerializeAsync<List<DateTime>>(fs, holidays);
            }
        }
    }
}
