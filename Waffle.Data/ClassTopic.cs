using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waffle.Data
	{
	[Table("Topics")]
	public class ClassTopic
		{
		[Key]
		public int TopicId { get; set; }

		public int ClassId { get; set; }


		[Required(ErrorMessage ="Please provide a title for this topic")]
		[MaxLength(50, ErrorMessage ="Topic cannot exceed 50 characters")]
		[Display(Name ="Topic Title")]
		public string Topic { get; set; }

		[Required]
		[Display(Name ="Position")]
		[Range(1, 100, ErrorMessage = "Position must be between 1 and 100")]
		public short Order { get; set; } //position of topic in class

		//navigational properties
		[ForeignKey("ClassId")]
		public Class Class { get; set; }
		public ICollection<Playlist> Playlists { get; set; }

		}
	}
