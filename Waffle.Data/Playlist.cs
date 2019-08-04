using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Waffle.Data
	{

	[Table(name: "Playlists")]
	public class Playlist
		{
		[Key]
		public int PlaylistId { get; set; }

		public int TopicId { get; set; }

		[Required(ErrorMessage ="Playlist Title is required")]
		public string Title { get; set; }
		
		public string VideoPath { get; set; }

		[Range(1, 100, ErrorMessage = "Position must be between 1 and 100")]
		public int Order { get; set; } //position in playlist 

		//navigational properties
		[ForeignKey("TopicId")]
		public ClassTopic ClassTopic { get; set; }

		}
	}
