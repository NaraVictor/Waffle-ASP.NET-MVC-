using System.Collections.Generic;
using Waffle.Data;

namespace Waffle.Repository.Interface
	{
	public interface IUser
		{

		IEnumerable<T> GetClasses<T>(string userId) where T : class;
        IEnumerable<ClassTopic> GetTopics(string userId, int classId);



		}
	}
