using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class InvoinceController : Controller
    {
        // GET: Invoince
        Context con = new Context();

        public ActionResult Index()
        {
            var vals1 = con.Invoinces.ToList();
            return View(vals1);
        }

        [HttpGet]
        public ActionResult AddInvoince()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInvoince(Invoince i)
        {
            con.Invoinces.Add(i);
            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult BringInvoince(int id)
        {
            var vals2 = con.Invoinces.Find(id);
            return View("BringInvoince", vals2);
        }
        public ActionResult UpdateInvoince(Invoince i)
        {
            var val1 = con.Invoinces.Find(i.InvoinceID);

            val1.InvoinceSerialNo = i.InvoinceSerialNo;
            val1.InvoinceItemNo = i.InvoinceItemNo;
            val1.TaxOffice = i.TaxOffice;
            val1.Date = i.Date;
            val1.Hour = i.Hour;
            val1.Consigner = i.Consigner;
            val1.Recipient = i.Recipient;

            con.SaveChanges();
            return RedirectToAction("Index");
        }

        public ActionResult InvoinceDetail(int id)
        {
            var vals2 = con.InvoinceItems.Where(x => x.InvoinceID == id).ToList();
            return View(vals2);
        }

        [HttpGet]
        public ActionResult AddInvoinceItem()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddInvoinceItem(InvoinceItem i)
        {
            con.InvoinceItems.Add(i);
            con.SaveChanges();
            return RedirectToAction("InvoinceDetail");
        }
    }
}