using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aracİhale.Controllers
{
    public class RaporController : Controller
    {
        // GET: Rapor
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult Rapor()
        {
            return View();
        }
        [Authorize]
        public ActionResult OrtaZorlukRapor()
        {
            return View();
        }
        [Authorize]
        public ActionResult KompleksRapor()
        {
            return View();
        }
    }
}