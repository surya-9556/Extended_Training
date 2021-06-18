using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EFWithDropDown.Models;

namespace EFWithDropDown.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            using(MovisEntities mvc = new MovisEntities())
            {
                var dataEF = new SelectList(mvc.tbl_Movies.ToList(),"id","MovieName");
                TempData["MovEF"] = dataEF;
            }
            return View();
        }

        public ActionResult Linq()
        {
            MovisEntities mvc = new MovisEntities();
            var res = (from i in mvc.tbl_Movies
                       select i).ToList();
            return View(res);
        }
    }
}