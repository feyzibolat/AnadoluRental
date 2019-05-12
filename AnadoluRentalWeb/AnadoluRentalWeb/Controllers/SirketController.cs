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
    public class SirketController : Controller
    {
        // GET: Sirket
        public ActionResult Index()
        {
            try
            {
                IList<Sirket> sirketListesi = SelectAllSirket().ToList();
                return View(sirketListesi);
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        // GET: Sirket/Goruntule/5
        public ActionResult Goruntule(int id)
        {
            return View(SirketSecById(id));
        }

        // GET: Sirket/YeniOlustur
        public ActionResult YeniOlustur()
        {
            return View();
        }

        // POST: Sirket/YeniOlustur
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
                if (SirketEkle(collection["sirketAdi"], collection["sirketSehir"], collection["sirketAdres"], int.Parse(collection["sirketAracSayisi"]), int.Parse(collection["sirketPuani"])))
                    return RedirectToAction("Index");
                return View();
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                return View();
            }
        }

        // GET: Sirket/Duzenle/41
        public ActionResult Duzenle(int id)
        {
            try
            {
                return View(SirketSecById(id));
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu", ex);
            }
        }

        // POST: Sirket/Duzenle/41
        [HttpPost]
        public ActionResult Duzenle(int id, FormCollection collection)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                if (SirketGuncelle(id, collection["sirketAdi"], collection["sirketSehir"], collection["sirketAdres"], int.Parse(collection["sirketAracSayisi"]), int.Parse(collection["sirketPuani"])))
                    return RedirectToAction("Index");

                return View();
            }
            catch
            {
                return View();
            }
        }

        // GET: Sirket/Sil/41
        public ActionResult Sil(int id)
        {
            try
            {
                if (SirketSilById(id))
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

        private bool SirketEkle(string sirketAdi, string sirketSehir, string sirketAdres, int sirketAracSayisi, int sirketPuani)
        {
            try
            {
                using (var sirketBusiness = new SirketBusiness())
                {
                    return sirketBusiness.SirketEkle(new Sirket()
                    {
                        sirketAdi = sirketAdi,
                        sirketSehir = sirketSehir,
                        sirketAdres = sirketAdres,
                        sirketAracSayisi = sirketAracSayisi,
                        sirketPuani = sirketPuani
                    });
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        private bool SirketGuncelle(int sirketID, string sirketAdi, string sirketSehir, string sirketAdres, int sirketAracSayisi, int sirketPuani)
        {
            try
            {
                using (var sirketBusiness = new SirketBusiness())
                {
                    return sirketBusiness.SirketGuncelle(new Sirket()
                    {
                        sirketID = sirketID,
                        sirketAdi = sirketAdi,
                        sirketSehir = sirketSehir,
                        sirketAdres = sirketAdres,
                        sirketAracSayisi = sirketAracSayisi,
                        sirketPuani = sirketPuani
                    });
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        private bool SirketSilById(int ID)
        {
            try
            {
                using (var sirketBusiness = new SirketBusiness())
                {
                    return sirketBusiness.SirketSilById(ID);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        private List<Sirket> SelectAllSirket()
        {
            try
            {
                using (var sirketBusiness = new SirketBusiness())
                {
                    List<Sirket> sirketList = new List<Sirket>();
                    foreach (var sirket in sirketBusiness.SelectAllSirket().OrderBy(x => x.sirketID).ToList())
                    {
                        Sirket secMus = new Sirket()
                        {
                            sirketID = sirket.sirketID,
                            sirketAdi = sirket.sirketAdi,
                            sirketSehir = sirket.sirketSehir,
                            sirketAdres = sirket.sirketAdres,
                            sirketAracSayisi = sirket.sirketAracSayisi,
                            sirketPuani = sirket.sirketPuani
                        };
                        sirketList.Add(secMus);
                    }
                    return sirketList;
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        private Sirket SirketSecById(int ID)
        {
            try
            {
                using (var sirketBusiness = new SirketBusiness())
                {
                    Sirket sirket = null;
                    Sirket donenSirket = sirketBusiness.SirketSecById(ID);
                    if (donenSirket != null)
                    {
                        sirket = new Sirket()
                        {
                            sirketID = donenSirket.sirketID,
                            sirketAdi = donenSirket.sirketAdi,
                            sirketSehir = donenSirket.sirketSehir,
                            sirketAdres = donenSirket.sirketAdres,
                            sirketAracSayisi = donenSirket.sirketAracSayisi,
                            sirketPuani = donenSirket.sirketPuani
                        };
                        List<Arac> sirketAraclari = new List<Arac>();
                        foreach (var gelenArac in donenSirket.Arac)
                        {
                            sirketAraclari.Add(new Arac()
                            {
                                aracID = gelenArac.aracID,
                                aracMarka = gelenArac.aracMarka,
                                aracModel = gelenArac.aracModel,
                                aracKM = gelenArac.aracKM,
                                airBagSayisi = gelenArac.airBagSayisi,
                                aitOlduguSirketID = gelenArac.aitOlduguSirketID,
                                bagacHacmi = gelenArac.bagacHacmi,
                                gerekenEhliyetYasi = gelenArac.gerekenEhliyetYasi,
                                gunlukKiralikFiyati = gelenArac.gunlukKiralikFiyati,
                                gunlukSinirKM = gelenArac.gunlukSinirKM,
                                koltukSayisi = gelenArac.koltukSayisi,
                                minYasSiniri = gelenArac.minYasSiniri,
                                Sirket = sirket
                            });
                        }

                        //sirket.Arac.AddRange(sirketAraclari);
                    }

                    return sirket;
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