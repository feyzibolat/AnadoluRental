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
    public class AracController : Controller
    {
        // GET: Arac
        public ActionResult Index()
        {
            try
            {
                IList<Arac> aracListesi = SelectAllArac().ToList();
                return View(aracListesi);
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        // GET: Arac/Goruntule/5
        public ActionResult Goruntule(int id)
        {
            return View(AracSecById(id));
        }

        // GET: Arac/YeniOlustur
        public ActionResult YeniOlustur()
        {
            return View();
        }

        // POST: Arac/YeniOlustur
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
                if (AracEkle(collection["aracMarka"], collection["aracModel"], int.Parse(collection["gerekenEhliyetYasi"]), int.Parse(collection["minYasSiniri"]), int.Parse(collection["gunlukSinirKM"]), int.Parse(collection["aracKM"]), int.Parse(collection["airBagSayisi"]), int.Parse(collection["bagacHacmi"]), int.Parse(collection["koltukSayisi"]), int.Parse(collection["gunlukKiralikFiyati"]), int.Parse(collection["aitOlduguSirketID"])))
                    return RedirectToAction("Index");
                return View();
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                return View();
            }
        }

        // GET: Arac/Duzenle/41
        public ActionResult Duzenle(int id)
        {
            try
            {
                return View(AracSecById(id));
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu", ex);
            }
        }

        // POST: Arac/Duzenle/41
        [HttpPost]
        public ActionResult Duzenle(int id, FormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                if (AracGuncelle(id, collection["aracMarka"], collection["aracModel"], int.Parse(collection["gerekenEhliyetYasi"]), int.Parse(collection["minYasSiniri"]), int.Parse(collection["gunlukSinirKM"]), int.Parse(collection["aracKM"]), int.Parse(collection["airBagSayisi"]), int.Parse(collection["bagacHacmi"]), int.Parse(collection["koltukSayisi"]), int.Parse(collection["gunlukKiralikFiyati"]), int.Parse(collection["aitOlduguSirketID"])))
                    return RedirectToAction("Index");

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Arac/Sil/41
        public ActionResult Sil(int id)
        {
            try
            {
                if (AracSilById(id))
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

        private bool AracEkle(string aracMarka, string aracModel, int gerekenEhliyetYasi, int minYasSiniri, int gunlukSinirKM, int aracKM, int airBagSayisi, int bagacHacmi, int koltukSayisi, int gunlukKiralikFiyati, int aitOlduguSirketID)
        {
            try
            {
                using (var aracBusiness = new AracBusiness())
                {
                    return aracBusiness.AracEkle(new Arac()
                    {
                        aracMarka = aracMarka,
                        aracModel = aracModel,
                        gerekenEhliyetYasi = gerekenEhliyetYasi,
                        minYasSiniri = minYasSiniri,
                        gunlukSinirKM = gunlukSinirKM,
                        aracKM = aracKM,
                        airBagSayisi = airBagSayisi,
                        bagacHacmi = bagacHacmi,
                        koltukSayisi = koltukSayisi,
                        gunlukKiralikFiyati = gunlukKiralikFiyati,
                        aitOlduguSirketID = aitOlduguSirketID
                    });
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        private bool AracGuncelle(int aracID, string aracMarka, string aracModel, int gerekenEhliyetYasi, int minYasSiniri, int gunlukSinirKM, int aracKM, int airBagSayisi, int bagacHacmi, int koltukSayisi, int gunlukKiralikFiyati, int aitOlduguSirketID)
        {
            try
            {
                using (var aracBusiness = new AracBusiness())
                {
                    return aracBusiness.AracGuncelle(new Arac()
                    {
                        aracID = aracID,
                        aracMarka = aracMarka,
                        aracModel = aracModel,
                        gerekenEhliyetYasi = gerekenEhliyetYasi,
                        minYasSiniri = minYasSiniri,
                        gunlukSinirKM = gunlukSinirKM,
                        aracKM = aracKM,
                        airBagSayisi = airBagSayisi,
                        bagacHacmi = bagacHacmi,
                        koltukSayisi = koltukSayisi,
                        gunlukKiralikFiyati = gunlukKiralikFiyati,
                        aitOlduguSirketID = aitOlduguSirketID
                    });
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        private bool AracSilById(int ID)
        {
            try
            {
                using (var aracBusiness = new AracBusiness())
                {
                    return aracBusiness.AracSilById(ID);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        private List<Arac> SelectAllArac()
        {
            try
            {
                using (var aracBusiness = new AracBusiness())
                {
                    List<Arac> aracList = new List<Arac>();
                    foreach (var arac in aracBusiness.SelectAllArac().OrderBy(x => x.aracID).ToList())
                    {
                        Arac secMus = new Arac()
                        {
                            aracID = arac.aracID,
                            aracMarka = arac.aracMarka,
                            aracModel = arac.aracModel,
                            gerekenEhliyetYasi = arac.gerekenEhliyetYasi,
                            minYasSiniri = arac.minYasSiniri,
                            gunlukSinirKM = arac.gunlukSinirKM,
                            aracKM = arac.aracKM,
                            airBagSayisi = arac.airBagSayisi,
                            bagacHacmi = arac.bagacHacmi,
                            koltukSayisi = arac.koltukSayisi,
                            gunlukKiralikFiyati = arac.gunlukKiralikFiyati,
                            aitOlduguSirketID = arac.aitOlduguSirketID
                        };
                        aracList.Add(secMus);
                    }
                    return aracList;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        private Arac AracSecById(int ID)
        {
            try
            {
                using (var aracBusiness = new AracBusiness())
                {
                    Arac arac = null;
                    Arac donenArac = aracBusiness.AracSecById(ID);
                    if (donenArac != null)
                    {
                        arac = new Arac()
                        {
                            aracID = donenArac.aracID,
                            aracMarka = donenArac.aracMarka,
                            aracModel = donenArac.aracModel,
                            gerekenEhliyetYasi = donenArac.gerekenEhliyetYasi,
                            minYasSiniri = donenArac.minYasSiniri,
                            gunlukSinirKM = donenArac.gunlukSinirKM,
                            aracKM = donenArac.aracKM,
                            airBagSayisi = donenArac.airBagSayisi,
                            bagacHacmi = donenArac.bagacHacmi,
                            koltukSayisi = donenArac.koltukSayisi,
                            gunlukKiralikFiyati = donenArac.gunlukKiralikFiyati,
                            aitOlduguSirketID = donenArac.aitOlduguSirketID
                        };
                        /*List<Musteri> kiraGecmisi = new List<Musteri>();
                        foreach (var gelenMus in donenArac.Musteri)
                        {
                            kiraGecmisi.Add(new Musteri()
                            {
                                musteriID = gelenMus.,
                                Arac = arac
                            });
                        }

                        //arac.Arac.AddRange(aracAraclari);*/
                    }

                    return arac;
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