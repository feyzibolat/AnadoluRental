using AnadoluRental.Business;
using AnadoluRental.CrossCutting.Concretes.Helper;
using AnadoluRental.CrossCutting.Concretes.Logger;
using AnadoluRental.Models.Models;
using AnadoluRentalWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace AnadoluRentalWeb.Controllers
{
    public class MusteriController : Controller
    {
        string Baseurl = "http://localhost:54361/";

        // GET: Musteri
        public async Task<ActionResult> Index()
        {
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");


            Kullanici gelenK = (Kullanici)Session["kull"];

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    IList<Kullanici> kullaniciListesi = null;
                    using (var result = await client.GetAsync("api/Kullanici"))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var value = result.Content.ReadAsStringAsync().Result;

                            //kullaniciListesi = JsonConvert.DeserializeObject<ResponseContent<Kullanici>>(value).Data.ToList();

                            if (gelenK.kullRolID == 1) // Admin ise..
                            {
                                kullaniciListesi = JsonConvert.DeserializeObject<ResponseContent<Kullanici>>(value).Data.ToList();
                            }
                            else if ((gelenK.kullRolID == 2 || gelenK.kullRolID == 3) && gelenK.kullSirketID > 0) // Yönetici veya Çalışan ise..
                            {
                                kullaniciListesi = JsonConvert.DeserializeObject<ResponseContent<Kullanici>>(value).Data.Where(kull => (kull.kullSirketID == gelenK.kullSirketID && kull.kullRolID == 4)).ToList();
                            }
                            else
                            {
                                kullaniciListesi = null;
                            }
                        }
                    }
                    return View(kullaniciListesi);
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu" + ex.Message);
            }
        }

        // GET: Kullanici/Goruntule/5
        public ActionResult Goruntule(int id)
        {
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");

            return View(id);
        }

        // GET: Kullanici/YeniOlustur
        public ActionResult YeniOlustur()
        {
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        // POST: Kullanici/YeniOlustur
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> YeniOlustur(FormCollection collection)
        {
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {

                int kullSirketID = 0;
                Kullanici gelenK = (Kullanici)Session["kull"];
                // Eğer ekleyen kişi adminse 0 değilse ekleyenin şirketIDsi müşterinin bağlı olduğu şirket IDsi olur.
                if (gelenK.kullRolID != 1)
                    kullSirketID = int.Parse(gelenK.kullSirketID.ToString());


                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    Kullanici kullanici = new Kullanici()
                    {
                        kullAdi = collection["kullAdi"],
                        kullSifre = collection["kullSifre"],
                        kullRolID = 4,
                        kullSirketID = kullSirketID,
                        Ad = collection["Ad"],
                        Soyad = collection["Soyad"],
                        TelNo = collection["TelNo"],
                        Adres = collection["Adres"]
                    };

                    var serializedProduct = JsonConvert.SerializeObject(kullanici);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("api/Kullanici", content);
                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                    return View();
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                return View();
            }
        }

        // GET: Kullanici/Duzenle/41
        public async Task<ActionResult> Duzenle(int id)
        {
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    Kullanici kullanici = null;

                    using (var result = await client.GetAsync("api/Kullanici/" + id))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var value = result.Content.ReadAsStringAsync().Result;

                            kullanici = JsonConvert.DeserializeObject<ResponseContent<Kullanici>>(value).Data.ToList().First();

                            return View(kullanici);
                        }
                    }
                }
                return RedirectToAction("Index");
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu", ex);
            }
        }

        // POST: Kullanici/Duzenle/41
        [HttpPost]
        public async Task<ActionResult> Duzenle(int id, FormCollection collection)
        {
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                return View();
            }
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    int kullSirketID = 0;
                    Kullanici gelenK = (Kullanici)Session["kull"];
                    // Eğer guncelleyen kişi adminse 0 değilse ekleyenin şirketIDsi müşterinin bağlı olduğu şirket IDsi olur.
                    if (gelenK.kullRolID != 1)
                        kullSirketID = int.Parse(gelenK.kullSirketID.ToString());


                    Kullanici kullanici = new Kullanici()
                    {
                        kullaniciID = id,
                        kullAdi = collection["kullAdi"],
                        kullSifre = collection["kullSifre"],
                        kullRolID = 4,
                        kullSirketID = kullSirketID,
                        Ad = collection["Ad"],
                        Soyad = collection["Soyad"],
                        TelNo = collection["TelNo"],
                        Adres = collection["Adres"]
                    };

                    var serializedProduct = JsonConvert.SerializeObject(kullanici);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync("api/Kullanici/" + id, content);
                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("Index");

                    return View();
                }
            }
            catch
            {
                return View();
            }
        }

        // GET: Kullanici/Sil/41
        public async Task<ActionResult> Sil(int id)
        {
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    var result = await client.DeleteAsync("api/Kullanici/" + id);
                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                throw new Exception("Hata Oluştu", ex);
            }
        }
    }
}