using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aracİhale.Controllers
{
    public class StokController : Controller
    {
        // GET: Stok
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]

        public ActionResult StokYonetimi()
        {
            return View();
        }
        [Authorize]
        public ActionResult StokYonetimiDetay()
        {
            return View();
        }
    }
}