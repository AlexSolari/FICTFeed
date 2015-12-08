using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Serialization;

namespace FICTFeed.Framework.Shedule
{
    /*
     * TODO: REFACTOR NEEDED
     * - split this classes (1 file per class)
     * ALSO:
     * - implement group page and shedule editing
     */

    public class Schedule
    {
        public List<WeekSchedule> Weeks { get; set; }

        public Schedule() : this(0, 0, 0)
        {

        }

        public DaySchedule GetScheduleForToday()
        {
            var today = DateTime.Today;
            var yearWhenStudyStarted = (DateTime.Now.Month < 9) ? DateTime.Today.Year - 1 : DateTime.Today.Year;
            var firstWeek = new DateTime(yearWhenStudyStarted, 9, 1);
            while (firstWeek.DayOfWeek != DayOfWeek.Monday)
            {
                firstWeek = firstWeek.AddDays(1);
            }
            var firstWeekNumber = CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(firstWeek, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            var currentWeekNumber = 1 + CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(DateTime.Today, CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            if (DateTime.Today.Year > firstWeek.Year)
            {
                currentWeekNumber += CultureInfo.InvariantCulture.Calendar.GetWeekOfYear(new DateTime(firstWeek.Year, 12, 31), CalendarWeekRule.FirstFourDayWeek, DayOfWeek.Monday);
            }
            var delta = currentWeekNumber - firstWeekNumber;
            var dayofweek = (int)DateTime.Today.DayOfWeek - 1;
            var weeknumber = delta % 4;

            return Weeks[weeknumber].Days[dayofweek];
        }

        public Schedule(int weeksCount, int daysCount, int lessonsCount)
        {
            Weeks = new List<WeekSchedule>();
            while(Weeks.Count < weeksCount)
            {
                Weeks.Add(new WeekSchedule(daysCount, lessonsCount));
            }
        }
    }


    public class WeekSchedule
    {
        public List<DaySchedule> Days { get; set; }

        public WeekSchedule() : this(0, 0)
        {
                
        }

        public WeekSchedule(int daysCount, int lessonsCount)
        {
            Days = new List<DaySchedule>();
            while (Days.Count < daysCount)
            {
                Days.Add(new DaySchedule(lessonsCount));
            }
        }
    }

    public class DaySchedule
    {
        public List<Lesson> Lessons { get; set; }

        public DaySchedule() : this(0)
        {

        }

        public DaySchedule(int lessonsCount)
        {
            Lessons = new List<Lesson>();
            while (Lessons.Count < lessonsCount)
            {
                Lessons.Add(new Lesson());
            }
        }
    }

    public class Lesson
    {
        [UIHint("Time")]
        public DateTime Start { get; set; }
        [UIHint("Time")]
        public DateTime End { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int? Room { get; set; }

        public Lesson() { }

        public Lesson(DateTime start, DateTime end, string name, string teacher, int? room)
        {
            Start = start;
            End = end;
            Name = name;
            Teacher = teacher;
            Room = room;
        }
    }
}
