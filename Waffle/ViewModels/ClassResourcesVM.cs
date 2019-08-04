using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Waffle.Data;

namespace Waffle.ViewModels
    {
    public class ClassResourcesVM
        {
        public int ClassResourcesId { get; set; }

        public string Title { get; set; }

        public string Path { get; set; }

        [Required]
        public int ClassId { get; set; }

        [Required]
        public HttpPostedFileBase Upload { get; set; }

        public IEnumerable<ClassResources> Resources { get; set; }
        }
    }