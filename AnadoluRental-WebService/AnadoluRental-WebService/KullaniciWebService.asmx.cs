using AnadoluRental.Business;
using AnadoluRental.Models.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Services;

namespace AnadoluRental_WebService
{
    /// <summary>
    /// Summary description for KullaniciWebService
    /// </summary>
    [WebService(Namespace = "http://tempuri.org/")]
    [WebServiceBinding(ConformsTo = WsiProfiles.BasicProfile1_1)]
    [System.ComponentModel.ToolboxItem(false)]
    // To allow this Web Service to be called from script, using ASP.NET AJAX, uncomment the following line. 
    // [System.Web.Script.Services.ScriptService]
    public class KullaniciWebService : System.Web.Services.WebService
    {

        [WebMethod]
        public bool KullaniciEkle(Kullanici kull)
        {
            try
            {
                using (var business = new KullaniciBusiness())
                {
                    business.KullaniciEkle(kull);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public bool KullaniciGuncelle(Kullanici kull)
        {
            try
            {
                using (var business = new KullaniciBusiness())
                {
                    business.KullaniciGuncelle(kull);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public bool KullaniciSilById(int kullID)
        {
            try
            {
                using (var business = new KullaniciBusiness())
                {
                    business.KullaniciSilById(kullID);
                }
                return true;
            }
            catch (Exception)
            {
                return false;
            }
        }

        [WebMethod]
        public Kullanici[] SelectAllKullanici()
        {
            try
            {
                using (var business = new KullaniciBusiness())
                {
                    return business.SelectAllKullanici().ToArray();
                }
            }
            catch (Exception)
            {
                throw;
            }
        }

        [WebMethod]
        public Kullanici KullaniciSecById(int id)
        {
            try
            {
                using (var business = new KullaniciBusiness())
                {
                    return business.KullaniciSecById(id);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }
    }
}
