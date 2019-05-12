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
    public class LoginController : Controller
    {

        string Baseurl = "http://localhost:54361/";

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
        public async Task<ActionResult> KayitEt(FormCollection collection)
        {
            if (Session["kull"] == null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                    Kullanici kull = new Kullanici()
                    {
                        kullAdi = collection["kullAdi"],
                        kullSifre = collection["kullSifre"],
                        kullRolID = 4,
                        kullSirketID = 0,
                        Ad = collection["Ad"],
                        Soyad = collection["Soyad"],
                        TelNo = collection["TelNo"],
                        Adres = collection["Adres"]
                    };

                    var serializedProduct = JsonConvert.SerializeObject(kull);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("api/Kullanici", content);
                    
                    if (result.IsSuccessStatusCode)
                        RedirectToAction("Index", "Login");
                    else
                        RedirectToAction("KayitOl", "Login");
                }
            }
            return RedirectToAction("Index", "Home");
        }

        // POST: Login Kontrolü
        [HttpPost]
        public async Task<ActionResult> Kontrol(FormCollection collection)
        {
            if (Session["kull"] == null)
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));


                    List<Kullanici> kullanicilar = new List<Kullanici>();

                    using (var result = await client.GetAsync("api/Kullanici"))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var value = result.Content.ReadAsStringAsync().Result;

                            kullanicilar = JsonConvert.DeserializeObject<ResponseContent<Kullanici>>(value).Data.ToList();
                        }
                    }

                    foreach (Kullanici kull in kullanicilar)
                    {
                        if (kull.kullAdi == collection["kullAdi"] && kull.kullSifre == collection["kullSifre"])
                        {
                            Session["kull"] = kull;
                            return RedirectToAction("Index", "Home");
                        }
                    }
                }
                return RedirectToAction("Index", "Login");
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