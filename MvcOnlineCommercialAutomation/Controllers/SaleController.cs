using System;
using System.Linq;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class SaleController : Controller
    {
        // GET: Sale
        private readonly Context con = new Context();

        public ActionResult Index()
        {
            var vals1 = con.SalesTransactions.ToList();
            return View(vals1);
        }

        [HttpGet]
        public ActionResult AddSale()
        {
            var val1 = (from x in con.Products.ToList()
                select new SelectListItem
                {
                    Text = x.ProductName,
                    Value = x.ProductID.ToString()
                }).ToList();
            var val2 = (from x in con.Clients.ToList()
                select new SelectListItem
                {
                    Text = x.ClientFirstName + " " + x.ClientLastName,
                    Value = x.ClientID.ToString()
                }).ToList();
            var val3 = (from x in con.Employees.ToList()
                select new SelectListItem
                {
                    Text = x.EmployeeFirstName + " " + x.EmployeeLastName,
                    Value = x.EmployeeID.ToString()
                }).ToList();
            ViewBag.vl1 = val1;
            ViewBag.vl2 = val2;
            ViewBag.vl3 = val3;

            return View();
        }

        [HttpPost]
        public ActionResult AddSale(SalesTransaction sale)
        {
            sale.Date = DateTime.Parse(DateTime.Now.ToShortDateString());
            con.SalesTransactions.Add(sale);
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringSale(int id)
        {
            var val1 = (from x in con.Products.ToList()
                select new SelectListItem
                {
                    Text = x.ProductName,
                    Value = x.ProductID.ToString()
                }).ToList();
            var val2 = (from x in con.Clients.ToList()
                select new SelectListItem
                {
                    Text = x.ClientFirstName + " " + x.ClientLastName,
                    Value = x.ClientID.ToString()
                }).ToList();
            var val3 = (from x in con.Employees.ToList()
                select new SelectListItem
                {
                    Text = x.EmployeeFirstName + " " + x.EmployeeLastName,
                    Value = x.EmployeeID.ToString()
                }).ToList();
            ViewBag.vl1 = val1;
            ViewBag.vl2 = val2;
            ViewBag.vl3 = val3;
            var vals2 = con.SalesTransactions.Find(id);
            return View("BringSale", vals2);
        }

        public ActionResult UpdateSale(SalesTransaction sale)
        {
            var s1 = con.SalesTransactions.Find(sale.SaleID);

            s1.Product = sale.Product;
            s1.Client = sale.Client;
            s1.Employee = sale.Employee;
            s1.Amount = sale.Amount;
            s1.Price = sale.Price;
            s1.Total = sale.Total;
            s1.Date = DateTime.Parse(DateTime.Now.ToShortDateString());

            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailSale(int id)
        {
            var vals3 = con.SalesTransactions.Where(x => x.SaleID == id).ToList();
            return View(vals3);
        }
    }
}