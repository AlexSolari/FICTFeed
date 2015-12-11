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

        public static int GetWeekNumber()
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
            var weeknumber = delta % 4;

            return weeknumber;
        }

        public DaySchedule GetScheduleForToday()
        {
            var dayofweek = (int)DateTime.Today.DayOfWeek - 1;

            return Weeks[GetWeekNumber()].Days[dayofweek];
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
                Lessons.Add(new Lesson() { Number = Lessons.Count + 1 });
            }
        }
    }

    public class Lesson
    {
        private int _number;

        [XmlIgnore]
        [UIHint("Time")]
        public DateTime Start { get; set; }
        [XmlIgnore]
        [UIHint("Time")]
        public DateTime End { get; set; }
        public string Name { get; set; }
        public string Teacher { get; set; }
        public int? Room { get; set; }
        public int Number
        {
            get
            {
                return _number;
            }
            set
            {
                _number = value;
                MapStartTimes();
            }
        }

        public Lesson()
    	{

    	}

        public void MapStartTimes() 
        {
            Start = DateTime.Today;
            End = DateTime.Today;
            switch (Number)
            {
                case 1:
                    Start = Start.AddHours(8);
                    Start = Start.AddMinutes(0);
                    End = End.AddHours(9);
                    End = End.AddMinutes(20);
                    break;
                case 2:
                    Start = Start.AddHours(9);
                    Start = Start.AddMinutes(30);
                    End = End.AddHours(10);
                    End = End.AddMinutes(50);
                    break;
                case 3:
                    Start = Start.AddHours(11);
                    Start = Start.AddMinutes(10);
                    End = End.AddHours(12);
                    End = End.AddMinutes(30);
                    break;
                case 4:
                    Start = Start.AddHours(12);
                    Start = Start.AddMinutes(40);
                    End = End.AddHours(14);
                    End = End.AddMinutes(0);
                    break;
                case 5:
                    Start = Start.AddHours(14);
                    Start = Start.AddMinutes(10);
                    End = End.AddHours(15);
                    End = End.AddMinutes(30);
                    break;
                case 6:
                    Start = Start.AddHours(15);
                    Start = Start.AddMinutes(40);
                    End = End.AddHours(17);
                    End = End.AddMinutes(0);
                    break;
                case 7:
                    Start = Start.AddHours(17);
                    Start = Start.AddMinutes(20);
                    End = End.AddHours(18);
                    End = End.AddMinutes(40);
                    break;
                case 8:
                    Start = Start.AddHours(18);
                    Start = Start.AddMinutes(50);
                    End = End.AddHours(20);
                    End = End.AddMinutes(10);
                    break;
                default:
                    break;
            }
        }
    }
}
