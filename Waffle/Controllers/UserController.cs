using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.IO;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Waffle.Data;
using Waffle.Repository;
using Waffle.Repository.Concrete;
using Waffle.ViewModels;

namespace Waffle.Controllers
{
    //[Authorize]
    [RoutePrefix("user")]
    public class UserController : Controller
    {

        public UserController()
            {
            _db = WaffleContext.CreateDb();
            userRepo = new UserRepository();
            }

        
        private UserRepository userRepo;
        private WaffleContext _db; 



        // GET: Dashboard
        [Route("dashboard")]
        public ActionResult Dashboard()
        {
            return View();
        }


        [HttpGet]
        [Route("{userId}")]
        public new ActionResult Profile(int userId)
        {
            return View();
        }


        [Route("playlist/{userId}")]
        public ActionResult Playlist(string userId)
            {

            if (userId == "" || userId == null)
                {
                return HttpNotFound();
                }


            var list = _db.Class.Where(c => c.UserId == userId)
                   .Include(c => c.Types)
                   .OrderByDescending(c => c.DateCreated)
                   .ThenBy(c => c.Title)
                      .Select(c => new MyPlayListVM()
                          {
                          ClassId = c.ClassId,
                          Title = c.Title,
                          PosterSrc = c.PosterSrc,
                          Type = c.Types.Title,
                          DateCreated = c.DateCreated,
                          Price = c.Price,
                          Category = c.Categories.Name
                          })
                   .ToList();

            return View(list);

            }
        }
}