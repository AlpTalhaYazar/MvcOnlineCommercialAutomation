using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        Context con = new Context();
        public ActionResult Index()
        {
            return View();
        }

        [HttpGet]
        public PartialViewResult Partial1()
        {
            return PartialView();
        }
        [HttpPost]
        public ActionResult Partial1(Client c)
        {
            con.Clients.Add(c);
            con.SaveChanges();
            return PartialView();
        }
    }
}