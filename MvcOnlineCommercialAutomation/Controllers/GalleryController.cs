using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using MvcOnlineCommercialAutomation.Models.Classes;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class GalleryController : Controller
    {
        // GET: Gallery
        Context con = new Context();

        public ActionResult Index()
        {
            var vals1 = con.Products.ToList();
            return View(vals1);
        }
    }
}