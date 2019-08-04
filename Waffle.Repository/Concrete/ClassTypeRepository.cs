using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waffle.Data;

namespace Waffle.Repository.Concrete
	{
	public class ClassTypeRepository : Repository<ClassType>
		{

		public ClassTypeRepository():base(WaffleContext.CreateDb())
			{
            _db = WaffleContext.CreateDb();
			}

        private WaffleContext _db;

        //public IEnumerable<ClassType> GetAll(string title)
        //    {

        //    }




        public static ClassTypeRepository CreateRepo()
            {
            return new ClassTypeRepository();
            }


		}
	}
