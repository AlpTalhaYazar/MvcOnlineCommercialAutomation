using System.Linq;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;
using PagedList;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class CategoryController : Controller
    {
        // GET: Category
        private readonly Context con = new Context();

        public ActionResult Index(int page = 1)
        {
            var values = con.Categories.ToList().ToPagedList(page, 5);
            return View(values);
        }

        [HttpGet]
        public ActionResult AddCategory()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddCategory(Category c)
        {
            con.Categories.Add(c);
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteCategory(int id)
        {
            var ctg = con.Categories.Find(id);
            con.Categories.Remove(ctg);
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringCategory(int id)
        {
            var category = con.Categories.Find(id);
            return View("BringCategory", category);
        }

        public ActionResult UpdateCategory(Category c)
        {
            var ctg = con.Categories.Find(c.CategoryID);
            ctg.CategoryName = c.CategoryName;
            con.SaveChanges();
            return RedirectToAction("Index");
        }
    }
}