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

        [StringLength(50, ErrorMessage = "Must be between 3 and 50 characters", MinimumLength = 3)]
        [Required]
        public virtual string Name { get; set; }

        [UIHint("Shedule")]
        public Shedule GroupShedule { get; set; }

        public GroupEditViewModel() 
        {
            GroupShedule = new Shedule(4, 7, 8);
        }

        public GroupEditViewModel(string name) 
            : this()
        {
            Guard.ThrowIfEmptyString(name);

            this.Name = name;
        }
    }
}