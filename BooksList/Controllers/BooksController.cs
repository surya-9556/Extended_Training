using BooksList.Models;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace BooksList.Controllers
{
    [TestFixture]
    public class BooksController : Controller
    {
        [Test]
        // GET: Books
        public ActionResult Index()
        {
            BooksDetails BD = new BooksDetails();
            BD.Books = PassiningBooks();
            return View(BD);
        }
        [HttpPost]
        public ActionResult Index(BooksDetails BD)
        {
            BD.Books = PassiningBooks();
            var SeletedItem = BD.Books.Find(p => p.Value == BD.BookId.ToString());
            if (SeletedItem != null)
            {
                SeletedItem.Selected = true;
                TempData["Message"] = "Title: " + SeletedItem.Text;
                TempData["Message"] += "\\nQuantity: " + BD.Quantity;
            }
            return View(BD);
        }
        [Test]
        private static List<SelectListItem> PassiningBooks()
        {
            List<SelectListItem> item = new List<SelectListItem>();
            using (SqlConnection con = new SqlConnection("server=DESKTOP-87C5QHV;Integrated security=true;database=BookDb;Trusted_Connection=True;"))
            {
                using (SqlCommand cmd = new SqlCommand("select BookTitle, BookId from tbl_Book"))
                {
                    cmd.Connection = con;
                    con.Open();
                    using (SqlDataReader dr = cmd.ExecuteReader())
                    {
                        while (dr.Read())
                        {
                            item.Add(new SelectListItem
                            {
                                Text = dr["BookTitle"].ToString(),
                                Value = dr["BookId"].ToString()
                            });
                        }
                    }
                    con.Close();
                }
            }
            return item;
        }
    }
}