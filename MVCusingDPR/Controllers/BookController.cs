using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MVCusingDPR.Models;
using System.Data;
using System.Data.SqlClient;
using System.Configuration;
using Dapper;

namespace MVCusingDPR.Controllers
{
    public class BookController : Controller
    {
        // GET: Book
        public ActionResult Index()
        {
            List<BookModel> BKList = new List<BookModel>();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                BKList = dbcon.Query<BookModel>("select * from tbl_Book").ToList();
            }
            return View(BKList);
        }

        // GET: Book/Details/5
        public ActionResult Details(int id)
        {
            BookModel BKList = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                BKList = dbcon.Query<BookModel>("select * from tbl_Book where BookId =" + id, new { id }).SingleOrDefault(); 
            }
            return View(BKList);
        }

        // GET: Book/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Book/Create
        [HttpPost]
        public ActionResult Create(FormCollection collection, BookModel book)
        {
            try
            {
                // TODO: Add insert logic here
                using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
                {
                    string sqlQry = "insert into tbl_Book(BookTitle,AuthorId,BookPrice) values('" + book.BookTitle + "'," + book.AuthorId + "," + book.BookPrice + ")";
                    int rowins = dbcon.Execute(sqlQry);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Edit/5
        public ActionResult Edit(int id)
        {
            BookModel BKList = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                BKList = dbcon.Query<BookModel>("select * from tbl_Book where BookId =" + id, new { id }).SingleOrDefault();
            }
            return View(BKList);
        }

        // POST: Book/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection,BookModel model)
        {
            try
            {
                // TODO: Add update logic here
                using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
                {
                    string sqlQry = "update tbl_Book set BookTitle='" + model.BookTitle + "', AuthorId=" + model.AuthorId + ", BookPrice=" + model.BookPrice + " where BookId=" + id;
                    int rowins = dbcon.Execute(sqlQry);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Book/Delete/5
        public ActionResult Delete(int id)
        {
            BookModel BKList = new BookModel();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
            {
                BKList = dbcon.Query<BookModel>("select * from tbl_Book where BookId =" + id, new { id }).SingleOrDefault();
            }
            return View(BKList);
        }

        // POST: Book/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["BKConStr"].ConnectionString))
                {
                    string sqlQry = "delete from tbl_Book where BookId="+id ;
                    int rowins = dbcon.Execute(sqlQry);
                }
                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
