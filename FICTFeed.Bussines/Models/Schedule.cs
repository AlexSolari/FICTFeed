using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FICTFeed.Bussines.Models
{
    public class Schedule : Entity
    {
        public virtual string GroupId { get; set; }

        public virtual string DayId { get; set; }

        public virtual List<string> Subjects { get; set; } // TODO: Subjects to XML Fields in Schedule table in Database
    }
}
