using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Waffle.Data;

namespace Waffle.ViewModels
	{
	public class NewClassVM
		{
		public NewClassVM()
			{
            Price = 0m;
			}


		[MaxLength(150, ErrorMessage = "Title cannot exceed 150 characters")]
		[Required]
		public string Title { get; set; }


		[MinLength(20, ErrorMessage = "Needs a minimum of 20 characters")]
		[Required(ErrorMessage = "Write something about the class")]
		public string Description { get; set; }


        public HttpPostedFileBase PosterUpload { get; set; }


        [DataType(DataType.Currency)]
        [Required(ErrorMessage = "Class must be priced")]
        public decimal Price { get; set; }

    }
	}