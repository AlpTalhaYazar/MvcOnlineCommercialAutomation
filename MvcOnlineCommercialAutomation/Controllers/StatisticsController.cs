using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class StatisticsController : Controller
    {
        // GET: Statistics
        Context con = new Context();

        public ActionResult Index()
        {
            ViewBag.d1 = con.Clients.Count().ToString();
            ViewBag.d2 = con.Products.Count().ToString();
            ViewBag.d3 = con.Employees.Count().ToString();
            ViewBag.d4 = con.Categories.Count().ToString();
            ViewBag.d5 = con.Products.Sum(x => x.Stock).ToString();
            ViewBag.d6 = con.Products.Select(x => x.Brand).Distinct().Count().ToString();
            ViewBag.d7 = con.Products.Count(x => x.Stock <= 20).ToString();
            ViewBag.d8 = con.Products.GroupBy(x => x.Brand).Max(x => x.Count()).ToString();
            ViewBag.d9 = (con.Products.OrderByDescending(x => x.SalePrice)).Select(y => y.ProductName).FirstOrDefault().ToString(); //(from x in con.Products orderby x.SalePrice descending select x.ProductName).FirstOrDefault().ToString();
            ViewBag.d10 = (con.Products.OrderBy(x => x.SalePrice)).Select(y => y.ProductName).FirstOrDefault().ToString();          //(from x in con.Products orderby x.SalePrice ascending select x.ProductName).FirstOrDefault().ToString();
            ViewBag.d11 = (con.Products.Count(x => x.ProductName.StartsWith("Refrigerator"))).ToString();
            ViewBag.d12 = (con.Products.Count(x => x.ProductName == "Laptop")).ToString();
            ViewBag.d13 = con.Products.Where(x => x.ProductID == (con.SalesTransactions.GroupBy(y => y.ProductID).OrderByDescending(z => z.Count()).Select(a => a.Key).FirstOrDefault())).Select(b => b.ProductName).FirstOrDefault();
            ViewBag.d14 = (con.SalesTransactions.Sum(x => (int?)x.Total) ?? 0).ToString();
            ViewBag.d15 = con.SalesTransactions.Count(x => x.Date == DateTime.Today).ToString();
            ViewBag.d16 = ((con.SalesTransactions.Where(x => x.Date == DateTime.Today)).Sum(y => (int?)y.Total) ?? 0).ToString();

            return View();
        }

        public ActionResult SimpleTables()
        {
            //Class1 cs = new Class1();
            //cs.Val3 = con.Categories.ToList();

            var vl1 = (from x in con.Clients
                      group x by x.ClientCity into g
                      select new ClassGroup
                      {
                          City = g.Key,
                          Amount = g.Count()
                      });
            var vl2 = con.Clients.ToList();
            return View((vl1.ToList(), vl2));
        }        
        
        
    }
}