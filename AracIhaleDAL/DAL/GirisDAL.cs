using AracIhaleCore.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AracIhaleDAL.DAL
{
    public class GirisDAL
    {
        Model1 db = new Model1();
        public Kullanici KullaniciGetir(string kullaniciAdi, string sifre)
        {
            using (var db = new Model1
                ())
            {
                return db.Kullanicis.FirstOrDefault(u => u.KullaniciAdi == kullaniciAdi && u.Sifre == sifre && u.RolID != 2);
            }
        }
        public List<string> KullaniciRoluneGoreGetir(int? userId)
        {
            using (var db = new Model1())
            {
                var roles = (from ur in db.Kullanicis
                             join r in db.Rols on ur.RolID equals r.RolID
                             where ur.KullaniciID == userId
                             select r.RolAdi).ToList();
                return roles;
            }
        }
        public List<string> RolegoreKullanici(int? roleId)
        {
            using (var db = new Model1())
            {
                var menuNames = (from rm in db.RolMenus
                                 join mm in db.Menus on rm.MenuID equals mm.MenuID
                                 where rm.RolID == roleId
                                 select mm.MenuIsım).ToList();
                return menuNames;
            }
        }
   
        public bool GirisYap(Kullanici kullanici)
        {
        
            var loggedUser = KullaniciGetir(kullanici.KullaniciAdi, kullanici.Sifre);
          
                var yeniGiris = new Giri
                {
                    GirisID = loggedUser.KullaniciID,
                    GirisZamani = DateTime.Now,
                    RolID = loggedUser.RolID,
                    KullaniciAdi = loggedUser.KullaniciAdi,
                    KullaniciID = loggedUser.KullaniciID
                };
          
                db.Giris.Add(yeniGiris);
      
            return db.SaveChanges() > 0;
               
            
           
        }
    }
}
    
