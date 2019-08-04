//using System;
//using System.Collections.Generic;
//using System.IO;
//using System.Linq;
//using System.Web;
//using System.Web.Mvc;
//using Waffle.Data;
//using Waffle.Enums;
//using Waffle.Repository;
//using Waffle.Repository.Concrete;
//using Waffle.ViewModel;

//namespace Waffle.Models
//	{
//	public class CreateClass : Controller
//		{

//		private readonly ClassRepository repo =
//			new ClassRepository();

//		private string _errorMsg;

//		public string ErrorMsg
//			{
//			get { return _errorMsg; }
//			}





//        public CreateStatus NewClass(ClassVM vm)
//			{

//			try
//				{
//				if (vm.PosterUpload.ContentLength==0)
//					return CreateStatus.error;
					
//				if (!ModelState.IsValid)
//					return CreateStatus.inValidModel;
					

//				//check to ensure that a class with similar title does not exist.


				
//				//if we got here it means everything is OK!
//				var cls = new Class
//					{
//					Title = vm.Title,
//					Description = vm.Description,
//					UserId = "1",
//					CategoryId = vm.CategoryId,
//					Price = vm.Price
//					};

//				cls.DateCreated = cls.DateCreated == null ? DateTime.Today : cls.DateCreated;

//				//check file size and dimensions


//				//upload the file
//				var ext = Path.GetExtension(vm.PosterUpload.FileName);
//				var guid = Guid.NewGuid();
//				var file = guid + ext;
//				cls.PosterSrc = "~/Assets/uploads/images/" + file;
//				vm.PosterUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/uploads/images/"), file));
//				repo.Add(cls);

//				using (var _db = new WaffleContext())
//					{
//					_db.SaveChanges();
//					}

//				return CreateStatus.success;
//			}

//			catch (Exception e)
//				{
//				_errorMsg = e.Message;
//				return CreateStatus.error;
//				}
//	}

//		}
//	}