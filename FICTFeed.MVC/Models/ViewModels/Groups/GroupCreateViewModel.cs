using FICTFeed.Framework.Shedule;
using FICTFeed.Framework.Validation;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FICTFeed.MVC.Models.ViewModels.Groups
{
    public class GroupCreateViewModel
    {
        [StringLength(50, ErrorMessage = "Must be between 3 and 50 characters", MinimumLength = 3)]
        [Required]
        public virtual string Name { get; set; }

        public Shedule Shedule { get; set; }

        public GroupCreateViewModel()
        {
            Shedule = new Shedule();
        }

        public GroupCreateViewModel(string name)
            : this()
        {
            Guard.ThrowIfEmptyString(name);

            this.Name = name;
        }
    }
}