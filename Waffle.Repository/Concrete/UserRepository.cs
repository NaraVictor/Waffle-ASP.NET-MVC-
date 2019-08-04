using System.Collections.Generic;
using Waffle.Data;
using Waffle.Repository.Interface;
using System.Data.Entity;
using System.Linq;

namespace Waffle.Repository.Concrete
	{
	public class UserRepository : IUser
		{

        //private ApplicationDbContext _db = new ApplicationDbContext();
        private WaffleContext _db = WaffleContext.CreateDb();


		public IEnumerable<T> GetClasses<T>(string userId) where T : class
			{
			var list = _db.Class.Where(c => c.UserId == userId)
					.Include(c => c.Types)
					.OrderByDescending(c => c.DateCreated)
			   		.Select(c => new
						   {
						   id = c.ClassId,
						   title = c.Title,
						   poster = c.PosterSrc,
						   type = c.Types.Title,
						   date = c.DateCreated,
						   price = c.Price
						   })
					.ToList();
			yield return list as T;
			}



		public IEnumerable<ClassTopic> GetTopics(string userId, int classId)
			{
			return _db.ClassTopic.Where(c => c.ClassId == classId
					&& c.Class.UserId == userId)
					.OrderBy(t => t.Order)
					.ToList();
			}



        public static UserRepository CreateRepo()
            {
            return new UserRepository();
            }


		}
	}
