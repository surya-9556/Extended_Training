using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace EFWithDropDown.Controllers
{
    public class HomeController : Controller
    {
        // GET: Home
        public ActionResult Index()
        {
            ViewBag.MyTime = DateTime.Now.ToString();
            return RedirectToAction("GoHome", "Home");
        }
        public ActionResult GoHome()
        {
            ViewBag.MyTime = DateTime.Now.ToString();
            ViewData["Mytime1"] = DateTime.Now.ToString();
            TempData["MyTime2"] = DateTime.Now.ToString();
            return View("Home");
        }
    }
}