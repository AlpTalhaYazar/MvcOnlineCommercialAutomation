using System.Linq;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class DepartmentController : Controller
    {
        // GET: Department
        private readonly Context con = new Context();

        public ActionResult Index()
        {
            var vals1 = con.Departments.Where(x => x.Status == true).ToList();
            return View(vals1);
        }

        [HttpGet]
        public ActionResult AddDepartment()
        {
            return View();
        }

        [HttpPost]
        public ActionResult AddDepartment(Department d)
        {
            con.Departments.Add(d);
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteDepartment(int id)
        {
            var dep = con.Departments.Find(id);
            dep.Status = false;
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringDepartment(int id)
        {
            var department = con.Departments.Find(id);
            return View("BringDepartment", department);
        }

        public ActionResult UpdateDepartment(Department d)
        {
            var dpt = con.Departments.Find(d.DepartmentID);
            dpt.DepartmentName = d.DepartmentName;
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DetailDepartment(int id)
        {
            var vals2 = con.Employees.Where(x => x.DepartmentID == id).ToList();
            var dpt = con.Departments.Where(x => x.DepartmentID == id).Select(y => y.DepartmentName).FirstOrDefault();
            ViewBag.dptnm = dpt;
            return View(vals2);
        }

        public ActionResult DepartmentEmployeeSale(int id)
        {
            var vals3 = con.SalesTransactions.Where(x => x.EmployeeID == id).ToList();
            var empnm = con.Employees.Where(x => x.EmployeeID == id)
                .Select(y => y.EmployeeFirstName + " " + y.EmployeeLastName).FirstOrDefault();
            ViewBag.empnm = empnm;
            return View(vals3);
        }
    }
}