using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace Waffle.ViewModels
	{
	public class PlaylistVM
		{
		[Required(ErrorMessage = "Playlist Title is required")]
		public string Title { get; set; }

		public int TopicId { get; set; }

		public string VideoPath { get; set; }


		[Range(1, 100, ErrorMessage = "Position must be between 1 and 100")]
		[Required]
		[Display(Name = "Position")]
		public int Order { get; set; } //position in playlist 

		HttpPostedFileBase VideoUpload { get; set; }
		}
	}