using FICTFeed.Framework.Shedule;
using FICTFeed.Framework.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.ViewModels.Groups
{
    public class GroupEditViewModel
    {
        public virtual Guid Id { get; set; }

        [CustomizebleStringLength(50, 3)]
        [СustomizebleRequired]
        public virtual string Name { get; set; }

        [UIHint("Shedule")]
        public Schedule GroupSchedule { get; set; }

        public GroupEditViewModel() 
        {
            GroupSchedule = new Schedule(4, 7, 8);
        }

        public GroupEditViewModel(string name) 
            : this()
        {
            this.Name = name;
        }
    }
}