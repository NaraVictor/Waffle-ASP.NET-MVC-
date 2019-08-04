using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waffle.Data
	{

	[Table(name: "ClassCategories")]
	public class ClassCategory
		{
		public int ClassCategoryId { get; set; }
		public string Name { get; set; }

		//Navigational Properties
		public ICollection<Class> Classes { get; set; }

		}
	}
