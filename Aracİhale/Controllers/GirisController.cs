using AracIhaleCore.Entities;
using AracIhaleDAL.DAL;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;

namespace Aracİhale.Controllers
{
    public class GirisController : Controller
    {
        // GET: Giris
        Model1 db = new Model1();
        GirisDAL girisDAL = new GirisDAL();


        public ActionResult Index()
        {
            return View();
        }



        public ActionResult GirisYap()
        {
            return View();
        }


        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult GirisYap(Kullanici kullanici, bool hatirla = false)
        {
            var girisYapanKullanici = girisDAL.KullaniciGetir(kullanici.KullaniciAdi, kullanici.Sifre);
            if (girisYapanKullanici != null)
            {
                FormsAuthentication.SetAuthCookie(kullanici.KullaniciAdi, true);
                Session["UserId"] = girisYapanKullanici.KullaniciID;
                Session["UserName"] = girisYapanKullanici.KullaniciAdi;
                var roles = girisDAL.KullaniciRoluneGoreGetir(girisYapanKullanici.KullaniciID);
                Session["Roles"] = roles;
                Session["KullaniciAdi"] = girisYapanKullanici.KullaniciAdi;

                var menuName = girisDAL.RolegoreKullanici(girisYapanKullanici.RolID);
                Session["MenuNames"] = menuName;
                girisDAL.GirisYap(kullanici);

                if (hatirla)
                {
                    HttpCookie cookie = new HttpCookie("GirisYap");
                    cookie.Values.Add("kullanici", kullanici.KullaniciAdi);
                    cookie.Values.Add("sifre", kullanici.Sifre);
                    cookie.Expires = DateTime.Now.AddDays(30);
                    Response.Cookies.Add(cookie);
                }
                else if (!hatirla)
                {
                    HttpCookie cookie = Request.Cookies["GirisYap"];
                    if (cookie != null)
                    {
                        cookie.Expires = DateTime.Now.AddDays(-1);
                        Response.Cookies.Add(cookie);
                    }
                }
            


                return RedirectToAction("AracListeleme", "Arac");
            }
            else
            {
                ViewBag.Error="Eksik ya da hatali kullanıcı";

            }
            //else if (kullanici.RolID==2)
            //{

            //    ViewBag.Error2 = "Bu sayfaya kullanıcılar giris yapamaz";
            //}
            return View();
        }





        public ActionResult CikisYap()
        {

            FormsAuthentication.SignOut();

            return RedirectToAction("GirisYap");
        }
 
        protected override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);

            HttpCookie cookie = Request.Cookies["GirisYap"];
            if (cookie != null && cookie.Values["kullanici"] != null && cookie.Values["sifre"] != null)
            {
                ViewBag.Remember = true;
                ViewBag.Username = cookie.Values["kullanici"];
                ViewBag.Password = cookie.Values["sifre"];
            }
        }

    }
}
