using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waffle.Data;
using Waffle.Repository.Interface;

namespace Waffle.Repository.Concrete
    {
    public class ClassRepository : Repository<Class>, IClassRepository
        {

        public ClassRepository()
        : base(WaffleContext.CreateDb())
            {
            _db = WaffleContext.CreateDb();
            }

        private WaffleContext _db;


        public new IEnumerable<Class> GetAll()
            {
            return _db.Class.Include(c => c.Categories)
                .Include(c => c.Types)
                .OrderByDescending(c => c.DateCreated)
                .ToList();
            }


        public IEnumerable<Class> GetAll(string category)
            {
            return _db.Class
                .Where(c => c.Categories.Name == category)
                .Include(c => c.Types)
                .Include(c => c.Categories)
                .OrderByDescending(c => c.DateCreated)
                .ToList();
            }




        public Class EagerGetById(int id)
            {
            return _db.Class.Where(c => c.ClassId == id)
                    .Include(c => c.Categories)
                    .Include(c => c.Types)
                    .Include(c => c.Levels)
                    .SingleOrDefault();
            }


        public Class GetByTitle(string title)
            {
            return _db.Class.Where(c => c.Title.ToLower() == title.ToLower())
                    .SingleOrDefault();
            }



        public static ClassRepository CreateRepo()
            {
            return new ClassRepository();
            }


        }
    }
