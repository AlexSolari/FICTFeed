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
        public WeekShedule FirstWeek { get; set; }
        public WeekShedule SecondWeek { get; set; }
        public WeekShedule ThirdWeek { get; set; }
        public WeekShedule FourthWeek { get; set; }

        public Shedule()
        {
            FirstWeek = new WeekShedule();
            SecondWeek = new WeekShedule();
            ThirdWeek = new WeekShedule();
            FourthWeek = new WeekShedule();
        }
    }


    public class WeekShedule
    {
        public List<DayShedule> Day { get; set; }

        public WeekShedule()
        {
            Day = new List<DayShedule>();
            for (int i = 0; i < 7; i++)
            {
                Day.Add(new DayShedule());
            }
        }
    }

    public class DayShedule
    {
        public List<Lesson> Lessons { get; set; }

        public DayShedule()
        {
            Lessons = new List<Lesson>();
            for (int i = 0; i < 8; i++)
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
