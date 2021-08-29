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
            return View();
        }

        public PartialViewResult Partial1()
        {
            var vl1 = (from x in con.Products
                       group x by x.Category into g
                       select new ClassGroup1
                       {
                           Category = g.Key.CategoryName,
                           Percent = g.Count()
                       });
            ViewBag.d1 = (con.Products.Count());
            return PartialView(vl1.ToList());
        }
        public PartialViewResult Partial2()
        {
            var vl2 = (from x in con.Employees
                       group x by x.Department into g
                       select new ClassGroup2
                       {
                           Department = g.Key.DepartmentName,
                           Percent = g.Count()
                       });
            ViewBag.d2 = (con.Employees.Count());
            return PartialView(vl2.ToList());
        }
        public PartialViewResult Partial3()
        {
            var vl3 = (from x in con.Clients
                       group x by x.ClientCity into g
                       select new ClassGroup3
                       {
                           City = g.Key,
                           Percent = g.Count()
                       });
            ViewBag.d3 = (con.Clients.Count());
            return PartialView(vl3.ToList());
        }
        public PartialViewResult Partial4()
        {
            var vl4 = (from x in con.Products
                       group x by x.Brand into g
                       select new ClassGroup4
                       {
                           Brand = g.Key,
                           Percent = g.Count()
                       });
            ViewBag.d4 = (con.Products.Count());
            return PartialView(vl4.ToList());
        }
        public PartialViewResult Partial5()
        {
            var vl5 = con.Clients.ToList();
            return PartialView(vl5);
        }
        public PartialViewResult Partial6()
        {
            var vl6 = con.Products.ToList();
            return PartialView(vl6);
        }

    }
}