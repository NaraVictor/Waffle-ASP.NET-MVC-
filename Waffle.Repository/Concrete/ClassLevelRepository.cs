using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waffle.Data;

namespace Waffle.Repository.Concrete
	{
	public class ClassLevelRepository :Repository<ClassLevel>
		{
		public ClassLevelRepository():base(WaffleContext.CreateDb())
            {
            _db = WaffleContext.CreateDb();
            }

        private WaffleContext _db;

        public IEnumerable<ClassLevel> GetAll(string title)
            {

            return _db.ClassLevel
                .Where(l => l.Title.ToLower() == title.ToLower())
                .ToList();

            }


        public static ClassLevelRepository CreateRepo()
            {
            return new ClassLevelRepository();
            }

		}
	}
