using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aracİhale.Controllers
{
    public class KurumsalUyeOnayController : Controller
    {
        // GET: KurumsalUyeOnay
        public ActionResult Index()
        {
            return View();
        }
        [Authorize]
        public ActionResult KurumsalUyeOnay()
        {
            return View();
        }
        [Authorize]
        public ActionResult KurumsalUyeOnayDetay()
        {
            return View();
        }
    }
}