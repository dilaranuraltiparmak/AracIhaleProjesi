using AracIhaleCore.Entities;
using AracIhaleDAL.VM;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace AracIhaleDAL.DAL
{
    public class KullaniciIslemDAL
    {
        Model1 db = new Model1();
        public bool KullaniciEkle(KullaniciVM yeniKullanici)
        {

            var ekle = new Kullanici
            {
                KullaniciAdi=yeniKullanici.KullaniciAdi,
                BireyselKurumsalID=yeniKullanici.BireyselkurumsalID,
                AktifPasifID=yeniKullanici.AktifPasifID,
                Ad =yeniKullanici.Ad,
                Telefon=yeniKullanici.Telefon,
                Mail=yeniKullanici.Mail,    
                Sifre=yeniKullanici.Sifre,
                RolID=yeniKullanici.RolID,

            };
            db.Kullanicis.Add(ekle);
        
            return db.SaveChanges()>0; ;    
        }
    }
}
