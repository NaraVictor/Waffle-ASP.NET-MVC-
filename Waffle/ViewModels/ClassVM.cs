using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using Waffle.Data;

namespace Waffle.ViewModels
	{
	public class ClassVM
		{

        public ClassVM()
            {

            }

		public ClassVM(IEnumerable<ClassCategory> cats, 
						IEnumerable<ClassLevel> levels, IEnumerable<ClassType> types)
			{
			Categories = cats;
			Levels = levels;
			Types = types;
			}


        //public ClassVM(Class _class)
        //    {
        //    topicVM = new TopicVM(_class);
        //    }



        public int ClassId { get; set; }
        
        [MaxLength(200, ErrorMessage ="Title must not be more than 200 characters")]
		[Required(ErrorMessage ="Class must have a title")]
		public string Title { get; set; }


		[MinLength(20, ErrorMessage = "Needs a minimum of 20 characters")]
		[Required(ErrorMessage = "Write something about the class")]
		public string Description { get; set; }


		[DataType(DataType.ImageUrl)]
		[Display(Name = "Poster")]
		public string PosterSrc { get; set; }


		[DataType(DataType.Currency)]
		[Required(ErrorMessage = "Class must be priced")]
		public decimal Price { get; set; }


		[Display(Name = "Target Students")]
		public string TargetStudents { get; set; }


		[Display(Name = "Skills Requirements")]
		[Required(ErrorMessage = "Specify a requirement")]
		public string Requirements { get; set; }



        //Foreign keys
        [Required(ErrorMessage = "Select class category")]
        [Display(Name = "Category")]
        public int CategoryId { get; set; }


		[Display(Name = "Skill Level")]
        [Required(ErrorMessage = "Select class entry level")]
		public int LevelId { get; set; }


		[Display(Name = "Class Type")]
		[Required(ErrorMessage = "Select class pricing model")]
		public int TypeId { get; set; }

        public DateTime DateCreated { get; set; }

        public HttpPostedFileBase PosterUpload { get; set; }


        public IEnumerable<ClassCategory> Categories { get; set; }
		public IEnumerable<ClassLevel> Levels { get; set; }
		public IEnumerable<ClassType> Types { get; set; }
        //public TopicVM topicVM { get; set; }

        }
    }