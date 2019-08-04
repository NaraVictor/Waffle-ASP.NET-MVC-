using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waffle.Data;

namespace Waffle.Repository
	{
	public class WaffleContext : DbContext
		{

		public WaffleContext()
			:base("name=WaffleDb")
			{
			Configuration.LazyLoadingEnabled = false;
			}


		public DbSet<Class> Class { get; set; }
		public DbSet<ClassTopic> ClassTopic { get; set; }
		public DbSet<Playlist> Playlist { get; set; }
		public DbSet<ClassCategory> ClassCategory { get; set; }
		public DbSet<ClassLevel> ClassLevel { get; set; }
		public DbSet<ClassResources> ClassResource { get; set; }
		public DbSet<ClassType> ClassType { get; set; }
		public DbSet<ClassDiscussion> ClassDiscussion { get; set; }




        public static WaffleContext CreateDb()
            {
            return new WaffleContext();
            }

		}
	}
