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
    public class AracController : Controller
    {
        string Baseurl = "http://localhost:54361/";

        // GET: Arac
        public async Task<ActionResult> Index()
        {
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");

            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    IList<Arac> aracListesi = null;
                    using (var result = await client.GetAsync("api/Arac"))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var value = result.Content.ReadAsStringAsync().Result;

                            aracListesi = JsonConvert.DeserializeObject<ResponseContent<Arac>>(value).Data.ToList();
                        }
                    }
                    return View(aracListesi);
                }
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
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");

            return View(id);
        }

        // GET: Arac/YeniOlustur
        public ActionResult YeniOlustur()
        {
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        // POST: Arac/YeniOlustur
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
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    Arac arac = new Arac()
                    {
                        aracMarka = collection["aracMarka"],
                        aracModel = collection["aracModel"],
                        gerekenEhliyetYasi = int.Parse(collection["gerekenEhliyetYasi"]),
                        minYasSiniri = int.Parse(collection["minYasSiniri"]),
                        gunlukSinirKM = int.Parse(collection["gunlukSinirKM"]),
                        aracKM = int.Parse(collection["aracKM"]),
                        airBagSayisi = int.Parse(collection["airBagSayisi"]),
                        bagacHacmi = int.Parse(collection["bagacHacmi"]),
                        koltukSayisi = int.Parse(collection["koltukSayisi"]),
                        gunlukKiralikFiyati = int.Parse(collection["gunlukKiralikFiyati"]),
                        aitOlduguSirketID = int.Parse(collection["aitOlduguSirketID"])
                    };

                    var serializedProduct = JsonConvert.SerializeObject(arac);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("api/Arac", content);
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

        // GET: Arac/Duzenle/41
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

                    Arac arac = null;

                    using (var result = await client.GetAsync("api/Arac/" + id))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var value = result.Content.ReadAsStringAsync().Result;

                            arac = JsonConvert.DeserializeObject<ResponseContent<Arac>>(value).Data.ToList().First();

                            return View(arac);
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

        // POST: Arac/Duzenle/41
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

                    Arac arac = new Arac()
                    {
                        aracID = id,
                        aracMarka = collection["aracMarka"],
                        aracModel = collection["aracModel"],
                        gerekenEhliyetYasi = int.Parse(collection["gerekenEhliyetYasi"]),
                        minYasSiniri = int.Parse(collection["minYasSiniri"]),
                        gunlukSinirKM = int.Parse(collection["gunlukSinirKM"]),
                        aracKM = int.Parse(collection["aracKM"]),
                        airBagSayisi = int.Parse(collection["airBagSayisi"]),
                        bagacHacmi = int.Parse(collection["bagacHacmi"]),
                        koltukSayisi = int.Parse(collection["koltukSayisi"]),
                        gunlukKiralikFiyati = int.Parse(collection["gunlukKiralikFiyati"]),
                        aitOlduguSirketID = int.Parse(collection["aitOlduguSirketID"])
                    };

                    var serializedProduct = JsonConvert.SerializeObject(arac);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync("api/Arac/" + id, content);
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

        // GET: Arac/Sil/41
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

                    var result = await client.DeleteAsync("api/Arac/" + id);
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