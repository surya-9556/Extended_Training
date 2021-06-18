using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace DropDownFormMVC.Controllers
{
    public class MoviesController : Controller
    {
        // GET: Movies
        public ActionResult Index()
        {
            #region ViewBag
            List<SelectListItem> MoList = new List<SelectListItem>()
            {
                new SelectListItem{Text="Lincon",Value="1"},
                   new SelectListItem{Text="1917",Value="2"},
                   new SelectListItem{Text="Memoreis",Value="3"},
                   new SelectListItem{Text="Jojo rabbit",Value="4"},
                   new SelectListItem{Text="The dark knight",Value="5"},
                   new SelectListItem{Text="Tenet",Value="6"},
                   new SelectListItem{Text="Drunkik",Value="7"}
            };
            ViewBag.MovList = MoList;
            #endregion

            #region ViewData
            List<SelectListItem> MvdList = new List<SelectListItem>()
            {
                new SelectListItem{Text="The jurdgement day",Value="1"},
                   new SelectListItem{Text="1917",Value="2"},
                   new SelectListItem{Text="Memoreis",Value="3"},
                   new SelectListItem{Text="Jojo rabbit",Value="4"},
                   new SelectListItem{Text="The dark knight",Value="5"},
                   new SelectListItem{Text="Tenet",Value="6"},
                   new SelectListItem{Text="Drunkik",Value="7"}
            };
            ViewData["MvdList"] = MvdList;
            #endregion

            #region TempData
            List<SelectListItem> MtdList = new List<SelectListItem>()
            {
                new SelectListItem{Text="Joker",Value="1"},
                   new SelectListItem{Text="1917",Value="2"},
                   new SelectListItem{Text="Memoreis",Value="3"},
                   new SelectListItem{Text="Jojo rabbit",Value="4"},
                   new SelectListItem{Text="The dark knight",Value="5"},
                   new SelectListItem{Text="Tenet",Value="6"},
                   new SelectListItem{Text="Drunkik",Value="7"}
            };
            TempData["MtdList"] = MtdList;
            #endregion

            var Movieslist = new List<ColList>();
            foreach (MovieList Ml in Enum.GetValues(typeof(MovieList)))
            {
                Movieslist.Add(new ColList
                {
                    Value = (int)Ml,
                    Text = Ml.ToString()
                });
            }
            ViewBag.ENumMovlist = Movieslist;
            return View();
        }
        public enum MovieList
        {
            The_Shape_of_Water,
            Parasite,
            The_DarkKnight_rises,
            Interstellar,
            Inception,
            Titanic
        }
        public struct ColList
        {
            public int Value { get; set; }
            public string Text { get; set; }
        }
    }
}