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

        public Shedule()
        {
            Weeks = new List<WeekShedule>();
            while(Weeks.Count < 4)
            {
                Weeks.Add(new WeekShedule());
            }
        }
    }


    public class WeekShedule
    {
        public List<DayShedule> Days { get; set; }

        public WeekShedule()
        {
            Days = new List<DayShedule>();
            while (Days.Count < 7)
            {
                Days.Add(new DayShedule());
            }
        }
    }

    public class DayShedule
    {
        public List<Lesson> Lessons { get; set; }

        public DayShedule()
        {
            Lessons = new List<Lesson>();
            while (Lessons.Count < 8)
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
