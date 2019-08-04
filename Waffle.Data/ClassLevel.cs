using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waffle.Data
	{
	[Table(name:"ClassLevels")]
	public class ClassLevel
		{
		public int ClasslevelId { get; set; }

		[Required]
		public string Title { get; set; }


		//navigational properties
		public ICollection<Class> Classes { get; set; }
		
		}
	}
