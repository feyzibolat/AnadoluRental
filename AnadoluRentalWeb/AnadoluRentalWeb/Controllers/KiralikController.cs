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
    public class KiralikController : Controller
    {
        string Baseurl = "http://localhost:54361/";

        // GET: Kiralik
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

                    IList<Kiralik> kiralikListesi = null;
                    using (var result = await client.GetAsync("api/Kiralik"))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var value = result.Content.ReadAsStringAsync().Result;

                            kiralikListesi = JsonConvert.DeserializeObject<ResponseContent<Kiralik>>(value).Data.ToList();
                        }
                    }
                    return View(kiralikListesi);
                }
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
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");

            return View(id);
        }

        // GET: Kiralik/YeniOlustur
        public ActionResult YeniOlustur()
        {
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");

            return View();
        }

        // POST: Kiralik/YeniOlustur
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

                    Kiralik kiralik = new Kiralik()
                    {
                        kiralananAracID = int.Parse(collection["kiralananAracID"]),
                        kiraTarihi = DateTime.Parse(collection["kiraTarihi"]),
                        verilisKM = int.Parse(collection["verilisKM"]),
                        kiraBitisKM = int.Parse(collection["kiraBitisKM"]),
                        kiraAlinanUcret = int.Parse(collection["kiraAlinanUcret"]),
                        kiralayanKulID = int.Parse(collection["kiralayanKulID"])
                    };

                    var serializedProduct = JsonConvert.SerializeObject(kiralik);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("api/Kiralik", content);
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

        // GET: Kiralik/Duzenle/41
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

                    Kiralik kiralik = null;

                    using (var result = await client.GetAsync("api/Kiralik/" + id))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var value = result.Content.ReadAsStringAsync().Result;

                            kiralik = JsonConvert.DeserializeObject<ResponseContent<Kiralik>>(value).Data.ToList().First();

                            return View(kiralik);
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

        // POST: Kiralik/Duzenle/41
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

                    Kiralik kiralik = new Kiralik()
                    {
                        kiraID = id,
                        kiralananAracID = int.Parse(collection["kiralananAracID"]),
                        kiraTarihi = DateTime.Parse(collection["kiraTarihi"]),
                        verilisKM = int.Parse(collection["verilisKM"]),
                        kiraBitisKM = int.Parse(collection["kiraBitisKM"]),
                        kiraAlinanUcret = int.Parse(collection["kiraAlinanUcret"]),
                        kiralayanKulID = int.Parse(collection["kiralayanKulID"])
                    };

                    var serializedProduct = JsonConvert.SerializeObject(kiralik);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync("api/Kiralik/" + id, content);
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

        // GET: Kiralik/Sil/41
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

                    var result = await client.DeleteAsync("api/Kiralik/" + id);
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