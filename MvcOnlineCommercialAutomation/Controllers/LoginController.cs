using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
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
        public ActionResult Partial1(Client cR)
        {
            con.Clients.Add(cR);
            con.SaveChanges();
            return PartialView();
        }

        [HttpGet]
        public ActionResult ClientLogin1()
        {
            return View();
        }
        [HttpPost]
        public ActionResult ClientLogin1(Client cL)
        {
            var credential = con.Clients.FirstOrDefault(x => x.ClientMail == cL.ClientMail && x.ClientPassword == cL.ClientPassword);
            if (credential != null)
            {
                FormsAuthentication.SetAuthCookie(credential.ClientMail, false);
                Session["ClientMail"] = credential.ClientMail.ToString();
                return RedirectToAction("Index", "ClientPanel");
            }
            else
            {
                return RedirectToAction("Index", "Login");
            }
        }
    }
}