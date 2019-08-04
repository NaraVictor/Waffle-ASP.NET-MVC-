using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waffle.Data;
using Waffle.Repository.Interface;

namespace Waffle.Repository.Concrete
	{
	public class ClassPlaylistRepository : Repository<Playlist>, IClassPlaylist
		{

		public ClassPlaylistRepository() 
			: base(WaffleContext.CreateDb())
			{

			}




        public static ClassPlaylistRepository CreateRepo()
            {
            return new ClassPlaylistRepository();
            }


		}
	}
