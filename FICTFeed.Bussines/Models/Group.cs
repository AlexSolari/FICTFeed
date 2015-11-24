using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace FICTFeed.Bussines.Models
{
    public class Group : Entity
    {
        public virtual string Name { get; set; }

        public virtual IList<User> Users { get; set; }

        public virtual bool CanBeDeleted { get; set; }

        public virtual XmlDocument Shedule { get; set; }
    }
}
