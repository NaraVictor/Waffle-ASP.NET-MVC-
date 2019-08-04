using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Waffle.Data;
using Waffle.Repository;
using Waffle.Repository.Concrete;
using Waffle.ViewModels;

namespace Waffle.Controllers
    {

    [RoutePrefix("Class")]
    public class ClassController : Controller
        {

        public ClassController()
            {
            _db = WaffleContext.CreateDb();
            repo = ClassRepository.CreateRepo();
            cat = ClassCategoryRepository.CreateRepo();
            levels = ClassLevelRepository.CreateRepo();
            types = ClassTypeRepository.CreateRepo();
            }

        private ClassCategoryRepository cat;
        private ClassLevelRepository levels;
        private ClassTypeRepository types;
        private ClassRepository repo;
        private ClassTopicRepository topic;
        private ClassResourcesRepository resources;
        private WaffleContext _db;


        private ClassVM CompleteClass()
            {
            return new ClassVM(cat.GetAll(), levels.GetAll(), types.GetAll());
            }


        //private ClassVM CompleteClass(Class cl)
        //    {
        //    return new ClassVM(cat.GetAll(cl.Categories.Name), levels.GetAll(cl.Levels.Title),
        //        types.GetAll());
        //    }




        [Route("{title}")]
        public ActionResult Index(string title)
            {
            if (title == null)
                return HttpNotFound();

            if (repo.GetByTitle(title) == null)
                return HttpNotFound();

            var mod = new ClassInfoVM(repo.GetByTitle(title));
            return View(mod);

            }



        //GET: Class/New
        [HttpGet]
        [Route("New")]
        public ActionResult New()
            {
            var mod = CompleteClass();
            return View(mod);
            }



        //POST: Class/New
        [HttpPost]
        [Route("New")]
        public ActionResult New(ClassVM vm)
            {
            if (vm.PosterUpload.ContentLength == 0)
                {
                ViewBag.err = "Class poster not uploaded";
                return View(vm);
                }


            if (repo.GetByTitle(vm.Title) != null)
                {
                ViewBag.err = "A Class with the same title exits. Try a different title";
                return View(vm);
                }


            //check file size and dimensions using a class & a static method


            if (!ModelState.IsValid)
                return View(vm);


            try
                {

                //if we got here it means everything is OK!
                var cls = new Class
                    {
                    Title = vm.Title,
                    Description = vm.Description,
                    UserId = "1",
                    Price = vm.Price,
                    DateCreated = DateTime.UtcNow,
                    CategoryId = vm.CategoryId,
                    TypeId = vm.TypeId,
                    LevelId = vm.LevelId,
                    Requirements = vm.Requirements,
                    TargetStudents = vm.TargetStudents
                    };



                //upload the file
                var ext = Path.GetExtension(vm.PosterUpload.FileName);
                var guid = Guid.NewGuid();
                var file = cls.UserId + guid + ext.ToLower();
                cls.PosterSrc = "~/Assets/Uploads/ClassCoverArts/" + file;
                vm.PosterUpload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Uploads/ClassCoverArts/"), file));
                repo.Add(cls);
                repo.db.SaveChanges();
                return RedirectToAction("Edit", "Class", new { id = cls.ClassId });

                }

            catch (Exception e)
                {
                ViewBag.err = e.Message; //+ ". Ensure that you have uploaded class image ... In production, do not expose e.Message";
                return View(vm);
                }

            }





        //GET: Library/Edit
        [HttpGet]
        [Route("Edit/{id}")]
        public ActionResult Edit(int id)
            {
            var cl = repo.GetById(id);
            if (cl == null)
                return HttpNotFound();

            try
                {
                var cls = CompleteClass();

                cls.Title = cl.Title;
                cls.Description = cl.Description;
                cls.Price = cl.Price;
                cls.PosterSrc = cl.PosterSrc;
                cls.CategoryId = cl.CategoryId;
                cls.LevelId = cl.LevelId;
                cls.Requirements = cl.Requirements;
                cls.TargetStudents = cl.TargetStudents;
                cls.TypeId = cl.TypeId;
                cls.ClassId = cl.ClassId;
                cls.DateCreated = cl.DateCreated;

                return View(cls);
                }
            catch
                {
                return RedirectToAction("Index", "Home");
                }

            }




        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("EditClass")]
        public ActionResult EditClass(ClassVM vm)
            {

            if (!ModelState.IsValid)
                return View(vm);


            //if (repo.GetByTitle(vm.Title).ClassId != vm.ClassId)
            //    {
            //    ViewBag.err = "A Class with the same title exits. Try a different title";
            //    return View(vm);
            //    }

            var cls = new Class
                {
                Title = vm.Title,
                Description = vm.Description,
                CategoryId = vm.CategoryId,
                Price = vm.Price,
                LevelId = vm.LevelId,
                TypeId = vm.TypeId,
                Requirements = vm.Requirements,
                TargetStudents = vm.TargetStudents,
                ClassId = vm.ClassId,
                DateCreated = vm.DateCreated,
                PosterSrc = vm.PosterSrc
                };


            //commit changes to db
            _db.Entry(cls).State = EntityState.Modified;
            _db.SaveChanges();
            return RedirectToAction("Edit", new { id = cls.ClassId });

            //try
            //    {
            //    //if we got here it means everything is OK!

            //    }

            //catch (Exception e)
            //    {
            //    ViewBag.err = e.Message;
            //    var cls = CompleteClass();
            //    return PartialView(cls);
            //    }

            }


        [HttpGet]
        [Route("Topics/{classId}")]
        public ActionResult Topics(int classId)
            {
            var mod = GetAllTopics(classId);
            return PartialView("PartialClassTopic", mod);
            }



        [HttpPost]
        [ValidateAntiForgeryToken]
        [Route("NewTopic")]
        public ActionResult NewTopic(TopicVM vm)
            {

            if (repo.GetById(vm.ClassId) == null)
                return HttpNotFound();


            if (ModelState.IsValid)
                {
                var top = new ClassTopic
                    {
                    Topic = vm.Topic,
                    ClassId = vm.ClassId,
                    Order = vm.Order
                    };

                _db.ClassTopic.Add(top);
                _db.SaveChanges();

                return PartialView("PartialAllClassTopics", GetAllTopics(top.ClassId));
                }

            return PartialView("PartialClassTopic", vm);
            }



        [HttpGet]
        [Route("Resources/{classId}")]
        public ActionResult Resources(int classId)
            {
            return PartialResources("PartialClassResources", classId);
            }




        [ValidateAntiForgeryToken]
        [HttpPost]
        [Route("AddResources")]
        public ActionResult AddResources(ClassResourcesVM vm)
            {

            if (!ModelState.IsValid)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (vm.Upload == null)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);

            if (vm.Upload.ContentLength == 0)
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);


            var clr = new ClassResources()
                {
                ClassId = vm.ClassId,
                Title = vm.Upload.FileName
                };

            var ext = Path.GetExtension(vm.Upload.FileName);
            var file = Path.GetFileNameWithoutExtension(clr.Title) + clr.ClassId + ext.ToLower();
            clr.Path = "~/Assets/Uploads/ClassResources/" + file;
            vm.Upload.SaveAs(Path.Combine(Server.MapPath("~/Assets/Uploads/ClassResources/"), file));

            _db.ClassResource.Add(clr);
            _db.SaveChanges();

            return PartialResources("PartialAllClassResources",clr.ClassId);
            }










        /// <summary>
        /// Returns a partial resource view based on a provided name and class id
        /// </summary>
        /// <param name="viewName">The name of the partial view to return</param>
        /// <param name="classId">The Class Id to query view data by</param>
        /// <returns></returns>

        private PartialViewResult PartialResources(string viewName, int classId)
            {
            var resources = ClassResourcesRepository.CreateRepo();
            var mod = new ClassResourcesVM
                {
                Resources = resources.GetByClassId(classId)
                };
            return PartialView(viewName, mod);
            }




        /// <summary>
        /// Returns all topics and playlist related to a particular class
        /// </summary>
        /// <param name="classId">The class id to query topics by</param>
        /// <returns></returns>

        private TopicVM GetAllTopics(int classId)
            {

            topic = ClassTopicRepository.CreateRepo();

            var mod = new TopicVM
                {
                AllTopics = topic.GetByClassId(classId),
                ClassId = classId
                };

            return mod;

            }

        }
    }
