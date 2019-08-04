using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waffle.Data;

namespace Waffle.Repository.Concrete
    {
    public class ClassCategoryRepository : Repository<ClassCategory>
        {
        public ClassCategoryRepository()
            : base(WaffleContext.CreateDb())
            {
            _db = WaffleContext.CreateDb();
            }

        private WaffleContext _db;


        public IEnumerable<ClassCategory> GetAll(string name)
            {

            return _db.ClassCategory
                .Where(c => c.Name.ToLower() == name.ToLower())
                .ToList();

            }



        public static ClassCategoryRepository CreateRepo()
            {
            return new ClassCategoryRepository();
            }

        }
    }
