using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.Entity;
using Waffle.Data;
using Waffle.Repository.Interface;

namespace Waffle.Repository.Concrete
    {
    public class ClassTopicRepository : Repository<ClassTopic>, IClassTopicRepository
        {

        public ClassTopicRepository() : base(WaffleContext.CreateDb())
            {
            _db = WaffleContext.CreateDb();
            }

        private WaffleContext _db;



        public IEnumerable<ClassTopic> GetByClassId(int classId)
            {
            return _db.ClassTopic
                .Where(t => t.ClassId == classId)
                .Include(t => t.Playlists)
                .OrderBy(t => t.Order)
                .ThenBy(t =>t.Topic)
                .ToList();
            }



        public static ClassTopicRepository CreateRepo()
            {
            return new ClassTopicRepository();
            }

        }
    }
