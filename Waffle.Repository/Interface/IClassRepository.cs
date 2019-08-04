using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Waffle.Data;
using Waffle.Repository.Concrete;

namespace Waffle.Repository.Interface
	{
	public interface IClassRepository: IRepository<Class>
		{
		IEnumerable<Class> GetAll(string category = "");
		}
	}
