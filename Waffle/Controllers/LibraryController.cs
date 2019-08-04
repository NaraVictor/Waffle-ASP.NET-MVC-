using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Waffle.Data;
using Waffle.Repository.Interface;
using Waffle.Repository.Concrete;
using Waffle.Repository;
using Waffle.ViewModels;
using System.IO;
using Waffle.Models;
using Waffle.Enums;

namespace Waffle.Controllers
    {
    [RoutePrefix("library")]
    public class LibraryController : Controller
        {

        private ClassRepository repo;

        public LibraryController()
            {
            repo = new ClassRepository();
            }



        // GET: Library
        public ActionResult Index()
            {
            return View(repo.GetAll());
            }

        }
    }
