using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using BooksEfData.Models;

namespace BooksEfData.Controllers
{
    public class BooksController : Controller
    {
        // GET: Books
        public ActionResult Index()
        {
            using (BooksEntities BE = new BooksEntities())
            {
                var Books = new SelectList(BE.tbl_Book.ToList(), "BookId", "BookTitle");
                TempData["Books"] = Books;
            }
            return View();
        }
    }
}