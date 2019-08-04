using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waffle.Data
	{
	public class ClassResources
		{
        [Key]
		public int ClassResourcesId { get; set; }

		[Required]
		public string Title { get; set; }
		
		[Required]
		public string Path { get; set; }

		public int ClassId { get; set; }
		

		//navigational property
		[ForeignKey("ClassId")]
		public Class Class { get; set; }
		
		}
	}
