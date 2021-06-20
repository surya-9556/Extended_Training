using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using Products.Models;

namespace Products.Controllers
{
    public class ProductController : Controller
    {
        AdventureWorksEntities AE = new AdventureWorksEntities();
        // GET: Product
        public ActionResult Index()
        {
            List<ProductCategory> productCategories = AE.ProductCategories.ToList();
            ViewBag.Productlist = new SelectList(productCategories, "ProductCategoryID", "Name");
            return View();
        }

        public JsonResult GetProducts(int ProductCategoryId)
        {
            AE.Configuration.ProxyCreationEnabled = false;
            List<ProductSubcategory> subcategories = AE.ProductSubcategories.Where(x=>x.ProductCategoryID == ProductCategoryId).ToList();
            return Json(subcategories, JsonRequestBehavior.AllowGet);
        }

        public JsonResult GetProduct(int ProductSubcategoryId)
        {
            AE.Configuration.ProxyCreationEnabled = false;
            List<Product> products = AE.Products.Where(x => x.ProductSubcategoryID == ProductSubcategoryId).ToList();
            return Json(products, JsonRequestBehavior.AllowGet);
        }
    }
}