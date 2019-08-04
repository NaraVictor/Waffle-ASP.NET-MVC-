using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Waffle.ViewModels
	{
	public class MyPlayListVM
		{
		public int ClassId { get; set; }

		[MaxLength(150, ErrorMessage = "Title cannot exceed 150 characters")]
		[Required]
		public string Title { get; set; }

	
		[MinLength(20, ErrorMessage = "Needs a minimum of 20 characters")]
		[Required(ErrorMessage = "Write something about the class")]
		public string Description { get; set; }


		[DataType(DataType.ImageUrl)]
		[Display(Name = "Poster")]
		public string PosterSrc { get; set; }


		[DataType(DataType.DateTime)]
		[Display(Name = "Date Created")]
		[ScaffoldColumn(false)]
		public DateTime DateCreated { get; set; }


		[DataType(DataType.Currency)]
		[Required(ErrorMessage = "Class must be priced")]
		public decimal Price { get; set; }

		[Display(Name = "Target Students")]
		public string TargetStudents { get; set; }


		[Display(Name = "Skills Requirements")]
		[Required(ErrorMessage = "Please specify a requirement")]
		public string Requirements { get; set; }


		[Display(Name = "Class Type")]
		[Required(ErrorMessage = "Please select class pricing model")]
		public string Type { get; set; }


		[ScaffoldColumn(false)] //author thus current user
		public string UserId { get; set; }


		public string Category { get; set; }


		[Display(Name = "Skill Level")]
		public string Level { get; set; }

		}
	}