using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        Context con = new Context();

        public ActionResult Index()
        {
            var Products = con.Products.Where(x => x.Status == true).ToList();

            return View(Products);
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            List<SelectListItem> val1 = (from x in con.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }).ToList();
            ViewBag.vl1 = val1;
            return View();
        }
        [HttpPost]
        public ActionResult AddProduct(Product p)
        {
            con.Products.Add(p);
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteProduct(int id)
        {
            var dp = con.Products.Find(id);
            dp.Status = false;
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringProduct(int id)
        {
            List<SelectListItem> val1 = (from x in con.Categories.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.CategoryName,
                                             Value = x.CategoryID.ToString()
                                         }).ToList();
            ViewBag.vl1 = val1;

            var product = con.Products.Find(id);
            return View("BringProduct", product);
        }
        public ActionResult UpdateProduct(Product p)
        {
            var prd = con.Products.Find(p.ProductID);
            prd.ProductName = p.ProductName;
            prd.Brand = p.Brand;
            prd.Stock = p.Stock;
            prd.PurchasePrice = p.PurchasePrice;
            prd.SalePrice = p.SalePrice;
            prd.CategoryID = p.CategoryID;
            prd.ProductImage = p.ProductImage;
            prd.Status = p.Status;

            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ProductList()
        {
            var vals1 = con.Products.ToList();
            return View(vals1);
        }

    }
}