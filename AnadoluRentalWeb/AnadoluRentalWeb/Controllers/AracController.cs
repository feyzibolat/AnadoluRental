using AnadoluRental.CrossCutting.Concretes.Helper;
using AnadoluRental.CrossCutting.Concretes.Logger;
using AnadoluRental.Models.Models;
using AnadoluRentalWeb.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.IO;
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

            Kullanici gelenK = (Kullanici)Session["kull"];

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

                            if (gelenK != null && (gelenK.kullRolID == 2 || gelenK.kullRolID == 3) && gelenK.kullSirketID > 0) // Yönetici veya Çalışan ise..
                            {
                                aracListesi = JsonConvert.DeserializeObject<ResponseContent<Arac>>(value).Data.Where(arac => (arac.aitOlduguSirketID == gelenK.kullSirketID)).ToList();
                            }
                            else
                            {
                                aracListesi = JsonConvert.DeserializeObject<ResponseContent<Arac>>(value).Data.ToList();
                            }
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
        public async Task<ActionResult> YeniOlustur()
        {
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");

            using (var client = new HttpClient())
            {
                client.BaseAddress = new Uri(Baseurl);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                IList<Sirket> sirketListesi = null;
                using (var result = await client.GetAsync("api/Sirket"))
                {
                    if (result.IsSuccessStatusCode)
                    {
                        var value = result.Content.ReadAsStringAsync().Result;

                        sirketListesi = JsonConvert.DeserializeObject<ResponseContent<Sirket>>(value).Data.ToList();
                    }
                }
                ViewBag.sirketListesi = sirketListesi;
            }
            return View();
        }

        // POST: Arac/YeniOlustur
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> YeniOlustur(FormCollection collection, HttpPostedFileBase uploadFile)
        {
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                return RedirectToAction("YeniOlustur");
            }
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    Arac yeniArac = new Arac();
                    yeniArac.aracMarka = collection["aracMarka"];
                    yeniArac.aracModel = collection["aracModel"];
                    yeniArac.gerekenEhliyetYasi = int.Parse(collection["gerekenEhliyetYasi"]);
                    yeniArac.minYasSiniri = int.Parse(collection["minYasSiniri"]);
                    yeniArac.gunlukSinirKM = int.Parse(collection["gunlukSinirKM"]);
                    yeniArac.aracKM = int.Parse(collection["aracKM"]);
                    yeniArac.airBagSayisi = int.Parse(collection["airBagSayisi"]);
                    yeniArac.bagacHacmi = int.Parse(collection["bagacHacmi"]);
                    yeniArac.koltukSayisi = int.Parse(collection["koltukSayisi"]);
                    yeniArac.gunlukKiralikFiyati = int.Parse(collection["gunlukKiralikFiyati"]);
                    if(collection["secilenSirket"]==null)
                        yeniArac.aitOlduguSirketID = int.Parse(collection["gelenK.kullSirketID"]);
                    else
                        yeniArac.aitOlduguSirketID = int.Parse(collection["secilenSirket"]);
                    //resim
                    if (uploadFile == null)
                    {
                        yeniArac.aracResim = "Content/img/arac/image_not_found.jpg";
                    }
                    else
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/img/arac"), Path.GetFileName(yeniArac.aracID + "_" + uploadFile.FileName));
                        string kayitYeri = "Content/img/arac/" + yeniArac.aracID + "_" + uploadFile.FileName;

                        string silEski = Server.MapPath("~/" + yeniArac.aracResim);
                        if (System.IO.File.Exists(silEski))
                        {
                            System.IO.File.Delete(silEski);
                        }

                        yeniArac.aracResim = kayitYeri;
                        uploadFile.SaveAs(path);
                    }

                    var serializedProduct = JsonConvert.SerializeObject(yeniArac);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PostAsync("api/Arac", content);
                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("Index");
                    return RedirectToAction("YeniOlustur");
                }
            }
            catch (Exception ex)
            {
                LogHelper.Log(LogTarget.File, ExceptionHelper.ExceptionToString(ex), true);
                return RedirectToAction("YeniOlustur");
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

                    IList<Sirket> sirketListesi = null;
                    using (var result = await client.GetAsync("api/Sirket"))
                    {
                        if (result.IsSuccessStatusCode)
                        {
                            var value = result.Content.ReadAsStringAsync().Result;

                            sirketListesi = JsonConvert.DeserializeObject<ResponseContent<Sirket>>(value).Data.ToList();
                        }
                    }
                    ViewBag.sirketList = sirketListesi;

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
        public async Task<ActionResult> Duzenle(int id, FormCollection collection, HttpPostedFileBase uploadFile)
        {
            if (Session["kull"] == null)
                return RedirectToAction("Index", "Home");

            if (!ModelState.IsValid)
            {
                return RedirectToAction("Index");
            }
            try
            {
                using (var client = new HttpClient())
                {
                    client.BaseAddress = new Uri(Baseurl);
                    client.DefaultRequestHeaders.Accept.Clear();
                    client.DefaultRequestHeaders.Accept.Add(
                        new MediaTypeWithQualityHeaderValue("application/json"));

                    Arac secilenArac = null;

                    using (var gelenArac = await client.GetAsync("api/Arac/" + id))
                    {
                        if (gelenArac.IsSuccessStatusCode)
                        {
                            var value = gelenArac.Content.ReadAsStringAsync().Result;

                            secilenArac = JsonConvert.DeserializeObject<ResponseContent<Arac>>(value).Data.ToList().First();
                            
                        }
                    }

                    secilenArac.aracMarka = collection["aracMarka"];
                    secilenArac.aracModel = collection["aracModel"];
                    secilenArac.gerekenEhliyetYasi = int.Parse(collection["gerekenEhliyetYasi"]);
                    secilenArac.minYasSiniri = int.Parse(collection["minYasSiniri"]);
                    secilenArac.gunlukSinirKM = int.Parse(collection["gunlukSinirKM"]);
                    secilenArac.aracKM = int.Parse(collection["aracKM"]);
                    secilenArac.airBagSayisi = int.Parse(collection["airBagSayisi"]);
                    secilenArac.bagacHacmi = int.Parse(collection["bagacHacmi"]);
                    secilenArac.koltukSayisi = int.Parse(collection["koltukSayisi"]);
                    secilenArac.gunlukKiralikFiyati = int.Parse(collection["gunlukKiralikFiyati"]);
                    if (collection["secilenSirket"] == null)
                        secilenArac.aitOlduguSirketID = int.Parse(collection["gelenK.kullSirketID"]);
                    else
                        secilenArac.aitOlduguSirketID = int.Parse(collection["secilenSirket"]);
                    //resim
                    if (uploadFile==null)
                    {
                        secilenArac.aracResim = secilenArac.aracResim;
                    }
                    else
                    {
                        string path = Path.Combine(Server.MapPath("~/Content/img/arac"), Path.GetFileName(id + "_" + uploadFile.FileName));
                        string kayitYeri = "Content/img/arac/" + id + "_" + uploadFile.FileName;

                        string silEski = Server.MapPath("~/" + secilenArac.aracResim);
                        if (System.IO.File.Exists(silEski) && secilenArac.aracResim != "Content/img/arac/image_not_found.jpg")
                        {
                            System.IO.File.Delete(silEski);
                        }

                        secilenArac.aracResim = kayitYeri;
                        uploadFile.SaveAs(path);
                    }



                    var serializedProduct = JsonConvert.SerializeObject(secilenArac);
                    var content = new StringContent(serializedProduct, Encoding.UTF8, "application/json");
                    var result = await client.PutAsync("api/Arac/" + id, content);
                    if (result.IsSuccessStatusCode)
                        return RedirectToAction("Index");


                    return RedirectToAction("Index");
                }
            }
            catch (Exception ex)
            {
                return RedirectToAction("Index");
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