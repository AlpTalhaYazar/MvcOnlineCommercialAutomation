using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class ClientPanelController : Controller
    {
        // GET: ClientPanel
        Context con = new Context();

        [Authorize]
        public ActionResult Index()
        {
            var Mail = (string)Session["ClientMail"];
            var vals1 = con.Clients.FirstOrDefault(x => x.ClientMail == Mail);
            ViewBag.m = Mail;
            return View(vals1);
        }

        public ActionResult MyOrders()
        {
            var Mail = (string)Session["ClientMail"];
            var id = con.Clients.Where(x => x.ClientMail == Mail.ToString()).Select(y => y.ClientID).FirstOrDefault();
            var vals2 = con.SalesTransactions.Where(x => x.ClientID == id).ToList();

            return View(vals2);
        }
    }
}