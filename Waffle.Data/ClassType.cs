using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waffle.Data
	{
	[Table(name: "ClassTypes")]
	public class ClassType
		{
		public int ClassTypeId { get; set; }

		[Required(ErrorMessage ="Please provide a type")]
		[MaxLength(100, ErrorMessage ="Title must not be longer than 100 characters")]
		public string Title { get; set; }

		//Navigational Properties
		public ICollection<Class> Classes { get; set; }

		}
	}
