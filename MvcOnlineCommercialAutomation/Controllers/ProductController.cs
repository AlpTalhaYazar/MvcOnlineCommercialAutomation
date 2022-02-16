using System.IO;
using System.Linq;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class ProductController : Controller
    {
        // GET: Product
        private readonly Context con = new Context();

        public ActionResult Index(string p)
        {
            var Products = from x in con.Products select x;
            if (!string.IsNullOrEmpty(p)) Products = Products.Where(y => y.ProductName.Contains(p));

            return View(Products.ToList());
        }

        [HttpGet]
        public ActionResult AddProduct()
        {
            var val1 = (from x in con.Categories.ToList()
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
            if (Request.Files.Count > 0)
            {
                var fileName = Path.GetFileName(Request.Files[0].FileName);
                var extens = Path.GetExtension(Request.Files[0].FileName);
                var path = "~/Image/" + fileName + extens;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.ProductImage = "/Image/" + fileName + extens;
            }

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
            var val1 = (from x in con.Categories.ToList()
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
            if (Request.Files.Count > 0)
            {
                var fileName = Path.GetFileName(Request.Files[0].FileName);
                var extens = Path.GetExtension(Request.Files[0].FileName);
                var path = "~/Image/" + fileName + extens;
                Request.Files[0].SaveAs(Server.MapPath(path));
                p.ProductImage = "/Image/" + fileName + extens;
            }

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

        [HttpGet]
        public ActionResult MakeSale()
        {
            var val3 = (from x in con.Employees.ToList()
                select new SelectListItem
                {
                    Text = x.EmployeeFirstName + " " + x.EmployeeLastName,
                    Value = x.EmployeeID.ToString()
                }).ToList();
            ViewBag.vl3 = val3;

            return View();
        }

        [HttpPost]
        public ActionResult MakeSale(SalesTransaction s)
        {
            return View();
        }
    }
}