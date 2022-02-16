using System.Linq;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class ToDoController : Controller
    {
        // GET: ToDo
        private readonly Context con = new Context();

        public ActionResult Index()
        {
            var vals1 = con.ToDos.ToList();

            var val1 = con.Clients.Count().ToString();
            ViewBag.d1 = val1;
            var val2 = con.Products.Count().ToString();
            ViewBag.d2 = val2;
            var val3 = con.Categories.Count().ToString();
            ViewBag.d3 = val3;
            var val4 = con.Clients.Select(x => x.ClientCity).Distinct().Count().ToString();
            ViewBag.d4 = val4;

            return View(vals1);
        }
    }
}