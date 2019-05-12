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
    public class KiralikController : Controller
    {
        // GET: Kiralik
        public ActionResult Index()
        {
            try
            {
                IList<Kiralik> kiralikListesi = SelectAllKiralik().ToList();
                return View(kiralikListesi);
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        // GET: Kiralik/Goruntule/5
        public ActionResult Goruntule(int id)
        {
            return View(KiralikSecById(id));
        }

        // GET: Kiralik/YeniOlustur
        public ActionResult YeniOlustur()
        {
            return View();
        }

        // POST: Kiralik/YeniOlustur
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult YeniOlustur(FormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                if (KiralikEkle(int.Parse(collection["kiralananAracID"]), DateTime.Parse(collection["kiraTarihi"]), int.Parse(collection["verilisKM"]), int.Parse(collection["kiraBitisKM"]), int.Parse(collection["kiraAlinanUcret"]), int.Parse(collection["kiralayanKulID"])))
                    return RedirectToAction("Index");
                return View();
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                return View();
            }
        }

        // GET: Kiralik/Duzenle/41
        public ActionResult Duzenle(int id)
        {
            try
            {
                return View(KiralikSecById(id));
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu", ex);
            }
        }

        // POST: Kiralik/Duzenle/41
        [HttpPost]
        public ActionResult Duzenle(int id, FormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                if (KiralikGuncelle(id, int.Parse(collection["kiralananAracID"]), DateTime.Parse(collection["kiraTarihi"]), int.Parse(collection["verilisKM"]), int.Parse(collection["kiraBitisKM"]), int.Parse(collection["kiraAlinanUcret"]), int.Parse(collection["kiralayanKulID"])))
                    return RedirectToAction("Index");

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Kiralik/Sil/41
        public ActionResult Sil(int id)
        {
            try
            {
                if (KiralikSilById(id))
                    return RedirectToAction("Index");
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu", ex);
            }
        }

        #region CRUD OPERATIONS

        private bool KiralikEkle(int kiralananAracID, DateTime kiraTarihi, int verilisKM, int kiraBitisKM, int kiraAlinanUcret, int kiralayanKulID)
        {
            try
            {
                using (var kiralikBusiness = new KiralikBusiness())
                {
                    return kiralikBusiness.AracKirala(new Kiralik()
                    {
                        kiralananAracID = kiralananAracID,
                        kiraTarihi = kiraTarihi,
                        verilisKM = verilisKM,
                        kiraBitisKM = kiraBitisKM,
                        kiraAlinanUcret = kiraAlinanUcret,
                        kiralayanKulID = kiralayanKulID
                    });
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        private bool KiralikGuncelle(int kiraID, int kiralananAracID, DateTime kiraTarihi, int verilisKM, int kiraBitisKM, int kiraAlinanUcret, int kiralayanKulID)
        {
            try
            {
                using (var kiralikBusiness = new KiralikBusiness())
                {
                    return kiralikBusiness.KiralikGuncelle(new Kiralik()
                    {
                        kiraID = kiraID,
                        kiralananAracID = kiralananAracID,
                        kiraTarihi = kiraTarihi,
                        verilisKM = verilisKM,
                        kiraBitisKM = kiraBitisKM,
                        kiraAlinanUcret = kiraAlinanUcret,
                        kiralayanKulID = kiralayanKulID
                    });
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        private bool KiralikSilById(int ID)
        {
            try
            {
                using (var kiralikBusiness = new KiralikBusiness())
                {
                    return kiralikBusiness.KiralikSilById(ID);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        private List<Kiralik> SelectAllKiralik()
        {
            try
            {
                using (var kiralikBusiness = new KiralikBusiness())
                {
                    List<Kiralik> kiralikList = new List<Kiralik>();
                    foreach (var kiralik in kiralikBusiness.SelectAllKiralik().OrderBy(x => x.kiraID).ToList())
                    {
                        Kiralik secMus = new Kiralik()
                        {
                            kiraID = kiralik.kiraID,
                            kiralananAracID = kiralik.kiralananAracID,
                            kiraTarihi = kiralik.kiraTarihi,
                            verilisKM = kiralik.verilisKM,
                            kiraBitisKM = kiralik.kiraBitisKM,
                            kiraAlinanUcret = kiralik.kiraAlinanUcret,
                            kiralayanKulID = kiralik.kiralayanKulID
                        };
                        kiralikList.Add(secMus);
                    }
                    return kiralikList;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        private Kiralik KiralikSecById(int ID)
        {
            try
            {
                using (var kiralikBusiness = new KiralikBusiness())
                {
                    Kiralik kiralik = null;
                    Kiralik donenKiralik = kiralikBusiness.KiralikSecById(ID);
                    if (donenKiralik != null)
                    {
                        kiralik = new Kiralik()
                        {
                            kiraID = donenKiralik.kiraID,
                            kiralananAracID = donenKiralik.kiralananAracID,
                            kiraTarihi = donenKiralik.kiraTarihi,
                            verilisKM = donenKiralik.verilisKM,
                            kiraBitisKM = donenKiralik.kiraBitisKM,
                            kiraAlinanUcret = donenKiralik.kiraAlinanUcret,
                            kiralayanKulID = donenKiralik.kiralayanKulID
                        };
                        /*List<Musteri> kiraGecmisi = new List<Musteri>();
                        foreach (var gelenMus in donenKiralik.Musteri)
                        {
                            kiraGecmisi.Add(new Musteri()
                            {
                                musteriID = gelenMus.,
                                Kiralik = kiralik
                            });
                        }

                        //kiralik.Arac.AddRange(kiralikAraclari);*/
                    }

                    return kiralik;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        #endregion
    }
}