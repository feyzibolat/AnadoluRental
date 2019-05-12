using AnadoluRentalWeb.AnadoluRentalKullaniciService;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnadoluRentalWeb.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            if (Session["kull"] == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Kayıt Ol
        public ActionResult KayitOl()
        {
            if (Session["kull"] == null)
            {
                return View();
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Kayıt Et
        [HttpPost]
        public ActionResult KayitEt(FormCollection collection)
        {
            if (Session["kull"] == null)
            {
                using (var kullSoapClient = new KullaniciWebServiceSoapClient())
                {
                    if (kullSoapClient.KullaniciEkle(new Kullanici()
                    {
                        kullAdi = collection["kullAdi"],
                        kullSifre = collection["kullSifre"],
                        kullRolID = 4,
                        kullSirketID = 0,
                        Ad = collection["Ad"],
                        Soyad = collection["Soyad"],
                        TelNo = collection["TelNo"],
                        Adres = collection["Adres"]
                    }))
                        RedirectToAction("Index", "Login");
                    else
                        RedirectToAction("KayitOl", "Login");
                }
            }
            return RedirectToAction("Index", "Home");
        }


        // POST: Login Kontrolü
        [HttpPost]
        public ActionResult Kontrol(FormCollection collection)
        {
            if (Session["kull"] == null)
            {
                using (var kullSoapClient = new KullaniciWebServiceSoapClient())
                {
                    List<Kullanici> kullanicilar = new List<Kullanici>();
                    foreach (var responsedKullanici in kullSoapClient.SelectAllKullanici().OrderBy(x => x.kullaniciID).ToList())
                    {
                        Kullanici kull = new Kullanici()
                        {
                            kullaniciID = responsedKullanici.kullaniciID,
                            kullAdi = responsedKullanici.kullAdi,
                            kullSifre = responsedKullanici.kullSifre,
                            kullRolID = responsedKullanici.kullRolID,
                            kullSirketID = responsedKullanici.kullSirketID,
                            Ad = responsedKullanici.Ad,
                            Soyad = responsedKullanici.Soyad,
                            TelNo = responsedKullanici.TelNo,
                            Adres = responsedKullanici.Adres
                        };
                        kullanicilar.Add(kull);
                    }

                    foreach (Kullanici kull in kullanicilar)
                    {
                        if (kull.kullAdi == collection["kullAdi"] && kull.kullSifre == collection["kullSifre"])
                        {
                            Session["kull"] = kull;
                            return RedirectToAction("Index", "Home");
                        }
                    }

                    return RedirectToAction("Index", "Login");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // Çıkış işlemi.
        public ActionResult Logout()
        {
            Session["kull"] = null;
            return RedirectToAction("Index", "Home");
        }
    }
}