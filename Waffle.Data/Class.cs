using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waffle.Data
	{
	
	[Table(name:"Classes")]
	public class Class
		{
        [Key]
		public int ClassId { get; set; }
		
		[MaxLength(200, ErrorMessage = "Title must not be more than 200 characters")]
        //[Index(IsUnique = true)]
        [Required(ErrorMessage ="Class must have a title")]
		public string Title { get; set; }

		[MinLength(20, ErrorMessage = "Needs a minimum of 20 characters")]
		[Required(ErrorMessage ="Write something about the class")]
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
		public string Requirements { get; set; }



		//Foreign keys
		[ScaffoldColumn(false)] //author thus current user
		public string UserId { get; set; }
		
        [Display(Name ="Category")]
		public int CategoryId { get; set; }
		
		[Display(Name = "Skill Level")]
		public int LevelId { get; set; }
		
		[Display(Name = "Class Type")]
		public int TypeId { get; set; }


		//navigational properties
		public ICollection<ClassTopic> Topics { get; set; }

		public ICollection<ClassDiscussion> Discussions { get; set; }
		
		public ICollection<ClassResources> Resources { get; set; }

		[ForeignKey("CategoryId")]
		public ClassCategory Categories { get; set; }

		[ForeignKey("LevelId")]
		public ClassLevel Levels { get; set; }

		[ForeignKey("TypeId")]
		public ClassType Types { get; set; }

		}
	}
