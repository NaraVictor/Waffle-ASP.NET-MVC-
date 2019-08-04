using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Waffle.Data;
using Waffle.Repository.Concrete;

namespace Waffle.ViewModels
    {
    public class TopicVM
        {

        [Required(ErrorMessage = "Provide a title for this topic")]
        [MaxLength(50, ErrorMessage = "Topic cannot exceed 50 characters")]
        [Display(Name = "Topic Title")]
        public string Topic { get; set; }

        [Required(ErrorMessage = "Provide a position number")]
        [Display(Name = "Position")]
        [Range(1, 100, ErrorMessage = "Position must be between 1 and 100")]
        public short Order { get; set; }

        public int ClassId { get; set; }
        
        public IEnumerable<ClassTopic> AllTopics { get; set; }

        }
    }