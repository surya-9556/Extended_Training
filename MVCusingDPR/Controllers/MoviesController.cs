using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Data;
using System.Data.SqlClient;
using Dapper;
using System.Configuration;
using MVCusingDPR.Models;

namespace MVCusingDPR.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            List<Movies> mov = new List<Movies>();
            using (IDbConnection dbCon = new SqlConnection(ConfigurationManager.ConnectionStrings["MovConStr"].ConnectionString))
            {
                mov = dbCon.Query<Movies>("select * from tbl_Movies").ToList();
            }
            return View(mov);
        }

        public ActionResult Details(int id=0)
        {
            Movies mov = new Movies();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MovConStr"].ConnectionString))
            {
                mov = dbcon.Query<Movies>("select * from tbl_Movies where id=" + id, new { id }).SingleOrDefault();
            }
            return View(mov);
        }

        [HttpGet]
        public ActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Create(Movies mov)
        {
            using (IDbConnection dbcon =  new SqlConnection(ConfigurationManager.ConnectionStrings["MovConStr"].ConnectionString))
            {
                string qry = "insert into tbl_Movies(MovieName) values('" + mov.MovieName + "')";
                int rowins = dbcon.Execute(qry);
            }
            return RedirectToAction("Index");
        }

        [HttpGet]
        public ActionResult Edit(int id=0)
        {
            Movies mov = new Movies();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MovConStr"].ConnectionString))
            {
                mov = dbcon.Query<Movies>("select * from tbl_Movies where id=" + id, new { id }).SingleOrDefault();
            }
            return View(mov);
        }

        [HttpPost]
        public ActionResult Edit(int id,Movies mov)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MovConStr"].ConnectionString))
            {
                string qry = "update tbl_Movies set MovieName = '" + mov.MovieName + "' where id=" + id;
                dbcon.Execute(qry);
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Delete(int id = 0)
        {
            Movies mov = new Movies();
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MovConStr"].ConnectionString))
            {
                mov = dbcon.Query<Movies>("select * from tbl_Movies where id=" + id, new { id }).SingleOrDefault();
            }
            return View(mov);
        }

        [HttpPost]
        public ActionResult Delete(int id,FormCollection col)
        {
            using (IDbConnection dbcon = new SqlConnection(ConfigurationManager.ConnectionStrings["MovConStr"].ConnectionString))
            {
                string qry = "delete from tbl_Movies where id=" + id;
                dbcon.Execute(qry);
            }
            return RedirectToAction("Index");
        }
    }
}