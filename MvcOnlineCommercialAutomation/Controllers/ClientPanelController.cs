using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MvcOnlineCommercialAutomation.Controllers
{
    public class ClientPanelController : Controller
    {
        // GET: ClientPanel
        [Authorize]
        public ActionResult Index()
        {
            return View();
        }
    }
}