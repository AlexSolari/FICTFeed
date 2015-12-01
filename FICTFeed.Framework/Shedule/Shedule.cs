using System;
using System.Collections.Generic;
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

    public class Shedule
    {
        public List<WeekShedule> Weeks { get; set; }

        public Shedule() : this(0, 0, 0)
        {

        }

        public Shedule(int weeksCount, int daysCount, int lessonsCount)
        {
            Weeks = new List<WeekShedule>();
            while(Weeks.Count < weeksCount)
            {
                Weeks.Add(new WeekShedule(daysCount, lessonsCount));
            }
        }
    }


    public class WeekShedule
    {
        public List<DayShedule> Days { get; set; }

        public WeekShedule() : this(0, 0)
        {
                
        }

        public WeekShedule(int daysCount, int lessonsCount)
        {
            Days = new List<DayShedule>();
            while (Days.Count < daysCount)
            {
                Days.Add(new DayShedule(lessonsCount));
            }
        }
    }

    public class DayShedule
    {
        public List<Lesson> Lessons { get; set; }

        public DayShedule() : this(0)
        {

        }

        public DayShedule(int lessonsCount)
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
        public DateTime Start { get; set; }
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
