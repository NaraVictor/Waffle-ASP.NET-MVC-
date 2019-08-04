using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waffle.Data
	{
	[Table(name:"ClassDiscussions")]
	public class ClassDiscussion
		{
		public int ClassDiscussionId { get; set; }
		
		[DataType(DataType.DateTime)]
		public DateTime Date { get; set; }
		
		[Required]
		public string Comment { get; set; }



		//Foreign Keys
		
		public string UserId { get; set; }

		public int ClassId { get; set; }
		

		//Navigational Properties
		[ForeignKey("ClassId")]
		public Class Class { get; set; }


		}
	}
