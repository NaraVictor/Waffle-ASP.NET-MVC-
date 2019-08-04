using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waffle.Data;
using Waffle.Repository.Interface;

namespace Waffle.Repository.Concrete
    {
    public class ClassResourcesRepository : Repository<ClassResources>, IClassResourcesRepository
        {

        public ClassResourcesRepository() : base(WaffleContext.CreateDb())
            {
            _db = WaffleContext.CreateDb();
            }

        private WaffleContext _db;


        public IEnumerable<ClassResources> GetByClassId(int id)
            {
            return _db.ClassResource
                   .Where(r => r.ClassId == id)
                   .ToList();

            }


        public static ClassResourcesRepository CreateRepo()
            {
            return new ClassResourcesRepository();
            }

        }
    }
