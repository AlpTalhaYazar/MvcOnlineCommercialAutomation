using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class EmployeeController : Controller
    {
        // GET: Employee
        Context con = new Context();

        public ActionResult Index()
        {
            var vals1 = con.Employees.ToList();
            return View(vals1);
        }

        [HttpGet]
        public ActionResult AddEmployee()
        {
            List<SelectListItem> val1 = (from x in con.Departments.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmentName,
                                             Value = x.DepartmentID.ToString()
                                         }).ToList();
            ViewBag.empdp = val1;
            return View();
        }
        [HttpPost]
        public ActionResult AddEmployee(Employee emp)
        {
            con.Employees.Add(emp);
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringEmployee(int id)
        {
            List<SelectListItem> val2 = (from x in con.Departments.ToList()
                                         select new SelectListItem
                                         {
                                             Text = x.DepartmentName,
                                             Value = x.DepartmentID.ToString()
                                         }).ToList();
            ViewBag.empdp = val2;

            var vals2 = con.Employees.Find(id);
            return View("BringEmployee", vals2);
        }
        public ActionResult UpdateEmployee(Employee emp)
        {
            var e1 = con.Employees.Find(emp.EmployeeID);

            e1.EmployeeFirstName = emp.EmployeeFirstName;
            e1.EmployeeLastName = emp.EmployeeLastName;
            e1.EmployeeImage = emp.EmployeeImage;
            e1.DepartmentID = emp.DepartmentID;

            con.SaveChanges();
            return RedirectToAction("Index");
        }

    }
}