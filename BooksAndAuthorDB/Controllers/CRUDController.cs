using BooksAndAuthorDB.Models;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksAndAuthorDB.Controllers
{
    public class CRUDController : Controller
    {
        // GET: CRUD
        public ActionResult Index()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.DisplayBook();
            return View("Home",dt);
        }

        public ActionResult Insert()
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.AuthorDisplay();
            return View("Create",dt);
        }

        public ActionResult InsertRecord(FormCollection frm,string action)
        {
            if(action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                string title = frm["txtTitle"];
                string aid = frm["txtaid"];
                double price = Convert.ToDouble(frm["txtPrice"]);
                int rowIns = mdl.NewBookS(title, aid, price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult Delete(int BookId)
        {
            CRUDModel mdl = new CRUDModel();
            mdl.DeleteBook(BookId);
            return RedirectToAction("Index");
        }

        public ActionResult Update(FormCollection frm, string action)
        {
            if (action == "Submit")
            {
                CRUDModel mdl = new CRUDModel();
                int bid = Convert.ToInt32(frm["txtbid"]);
                string title = frm["txtTitle"];
                int aid = Convert.ToInt32(frm["txtaid"]);
                double price = Convert.ToDouble(frm["txtPrice"]);
                int rowIns = mdl.UpdateBook(bid, title, aid, price);
                return RedirectToAction("Index");
            }
            else
            {
                return RedirectToAction("Index");
            }
        }

        public ActionResult EditBook(int BookId)
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.BookbyID(BookId);
            return View("Edit", dt);
        }

        public ActionResult Details(int BookId)
        {
            CRUDModel mdl = new CRUDModel();
            DataTable dt = mdl.BooksDetails(BookId);
            return View("Details", dt);
        }
    }
}