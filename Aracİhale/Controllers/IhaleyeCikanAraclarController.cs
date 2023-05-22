using AracIhaleCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace Aracİhale.Controllers
{
    public class IhaleyeCikanAraclarController : Controller
    {
        // GET: IhaleyeCikanAraclar
        Model1 db=new Model1();
        public ActionResult IhaleyeCikanAraclar()
        {
            var getir = db.IhaleTeklifs.ToList();
            return View(getir);
        }
    }
}