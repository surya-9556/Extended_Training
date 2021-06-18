using BooksAndAuthorDB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksAndAuthorDB.Controllers
{
    public class AuthorController : Controller
    {
        // GET: Author
        public ActionResult Index()
        {
            AuthorCRUD au = new AuthorCRUD();
            DataTable dt = au.Display();
            return View("Home",dt);
        }

        public ActionResult insert()
        {
            return View("Create");
        }

        public ActionResult insertRecord(FormCollection frm, string action)
        {
            if(action == "Submit")
            {
                AuthorCRUD au = new AuthorCRUD();
                string AUName = frm["txtName"];
                int rowIns = au.Name(AUName);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult edit()
        {
            return View("Edit");
        }

        public ActionResult EditRecord(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                AuthorCRUD au = new AuthorCRUD();
                int aid = Convert.ToInt32(frm["txtaid"]);
                string AUName = frm["txtName"];
                int rowIns = au.Update(aid,AUName);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }
    }
}