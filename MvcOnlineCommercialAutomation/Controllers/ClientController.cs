using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Controllers;

namespace MvcOnlineCommercialAutomation.Models.Classes
{
    public class ClientController : Controller
    {
        // GET: Client
        Context con = new Context();

        public ActionResult Index()
        {
            var vals1 = con.Clients.Where(x => x.Status == true).ToList();
            return View(vals1);
        }

        [HttpGet]
        public ActionResult AddClient()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddClient(Client cl)
        {
            con.Clients.Add(cl);
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult DeleteClient(int id)
        {
            var cl = con.Clients.Find(id);
            cl.Status = false;
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringClient(int id)
        {
            var client = con.Clients.Find(id);
            return View("BringClient", client);
        }
        public ActionResult UpdateClient(Client cl)
        {
            if (!ModelState.IsValid)
            {
                return View("BringClient");
            }
            var cli = con.Clients.Find(cl.ClientID);
            cli.ClientFirstName = cl.ClientFirstName;
            cli.ClientLastName = cl.ClientLastName;
            cli.ClientCity = cl.ClientCity;
            cli.ClientMail = cl.ClientMail;

            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult ClientPurchase(int id)
        {
            var vals2 = con.SalesTransactions.Where(x => x.ClientID == id).ToList();
            ViewBag.clnm = con.Clients.Where(x => x.ClientID == id).Select(y => y.ClientFirstName + " " + y.ClientLastName).FirstOrDefault();
            return View("ClientPurchase", vals2);
        }
    }
}