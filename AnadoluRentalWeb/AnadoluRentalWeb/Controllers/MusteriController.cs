using AnadoluRental.Business;
using AnadoluRental.CrossCutting.Concretes.Helper;
using AnadoluRental.CrossCutting.Concretes.Logger;
using AnadoluRental.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace AnadoluRentalWeb.Controllers
{
    public class MusteriController : Controller
    {
        // GET: Musteri
        public ActionResult Index()
        {
            if (Session["kull"] != null)
            {
                AnadoluRentalKullaniciService.Kullanici gelenK = (AnadoluRentalKullaniciService.Kullanici)Session["kull"];

                try
                {
                    using (var business = new KullaniciBusiness())
                    {
                        List<Kullanici> musteriler;

                        if (gelenK.kullRolID == 1) // Admin ise..
                        {
                            musteriler = business.SelectAllKullanici().ToList();
                        }
                        else if ((gelenK.kullRolID == 2 || gelenK.kullRolID == 3) && gelenK.kullSirketID > 0) // Yönetici veya Çalışan ise..
                        {
                            musteriler = business.SelectAllKullanici().Where(kull => kull.kullSirketID == gelenK.kullSirketID && (gelenK.kullRolID == 2 || gelenK.kullRolID == 3)).ToList();
                        }
                        else
                        {
                            musteriler = null;
                        }
                        return View(musteriler);
                    }
                }
                catch (Exception)
                {
                    throw;
                }
            }
            return RedirectToAction("Index", "Home");
        }

        KullaniciBusiness business = new KullaniciBusiness();

        // GET: Kullanici/Goruntule/5
        public ActionResult Goruntule(int id)
        {
            
            Kullanici kull = business.KullaniciSecById(id);
            return View(kull);
        }

        // GET: Kullanici/YeniOlustur
        public ActionResult YeniOlustur()
        {
            return View();
        }

        // POST: Kullanici/YeniOlustur
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YeniOlustur(FormCollection collection)
        {
            if (Session["kull"] != null)
            {
                AnadoluRentalKullaniciService.Kullanici gelenK = (AnadoluRentalKullaniciService.Kullanici)Session["kull"];


                if (!ModelState.IsValid)
                {
                    return View();
                }
                try
                {
                    if (business.KullaniciEkle(new Kullanici()
                    {
                        kullAdi = collection["kullAdi"],
                        kullSifre = collection["kullSifre"],
                        kullRolID = 4,
                        kullSirketID = gelenK.kullSirketID,
                        Ad = collection["Ad"],
                        Soyad = collection["Soyad"],
                        TelNo = collection["TelNo"],
                        Adres = collection["Adres"]
                    }))
                        return RedirectToAction("Index");
                    return View();
                }
                catch (Exception ex)
                {
                    LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                    return View();
                }
            }
            return RedirectToAction("Index","Home");
        }

        // GET: Kullanici/Duzenle/41
        public ActionResult Duzenle(int id)
        {
            try
            {
                using (var business = new KullaniciBusiness())
                {

                    return View(business.KullaniciSecById(id));
                }

            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu", ex);
            }
        }

        // POST: Kullanici/Duzenle/41
        [HttpPost]
        public ActionResult Duzenle(int id, FormCollection collection)
        {
            if (Session["kull"] != null)
            {
                AnadoluRentalKullaniciService.Kullanici gelenK = (AnadoluRentalKullaniciService.Kullanici)Session["kull"];


                if (!ModelState.IsValid)
                {
                    return View();
                }
                try
                {
                    if (business.KullaniciEkle(new Kullanici()
                    {
                        kullaniciID = id,
                        kullAdi = collection["kullAdi"],
                        kullSifre = collection["kullSifre"],
                        kullRolID = 4,
                        kullSirketID = gelenK.kullSirketID,
                        Ad = collection["Ad"],
                        Soyad = collection["Soyad"],
                        TelNo = collection["TelNo"],
                        Adres = collection["Adres"]
                    }))
                        return RedirectToAction("Index");
                    return View();
                }
                catch (Exception ex)
                {
                    LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                    return View();
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // GET: Kullanici/Sil/41
        public ActionResult Sil(int id)
        {
            try
            {
                if (business.KullaniciSilById(id))
                    return RedirectToAction("Index");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu", ex);
            }
        }
    }

}