using AnadoluRental.Business;
using AnadoluRental.Models.Models;
using AnadoluRental_WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;
using System.Web.Http.Cors;

namespace AnadoluRental_WebApi.Controllers
{
    [EnableCors(origins: "*", headers: "*", methods: "*")]
    public class KullaniciController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            using (var kullaniciBusiness = new KullaniciBusiness())
            {
                List<Kullanici> kullaniciList = kullaniciBusiness.SelectAllKullanici();
                
                var content = new ResponseContent<Kullanici>(kullaniciList);
                return new StandartResult<Kullanici>(content, Request);
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            ResponseContent<Kullanici> content;

            using (var kullaniciBusiness = new KullaniciBusiness())
            {
                List<Kullanici> kullaniciList = null;
                try
                {
                    var temp = kullaniciBusiness.KullaniciSecById(id);
                    if (temp != null)
                    {
                        kullaniciList = new List<Kullanici>();
                        kullaniciList.Add(temp);
                    }

                    content = new ResponseContent<Kullanici>(kullaniciList);
                    return new StandartResult<Kullanici>(content, Request);
                }
                catch (Exception)
                {
                    content = new ResponseContent<Kullanici>(null);
                    return new StandartResult<Kullanici>(content, Request);
                }
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Kullanici kullanici)
        {
            var content = new ResponseContent<Kullanici>(null);
            if (kullanici != null)
            {
                using (var kullaniciBusiness = new KullaniciBusiness())
                {
                    content.Result = kullaniciBusiness.KullaniciEkle(kullanici) ? "1" : "0";

                    return new StandartResult<Kullanici>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Kullanici>(content, Request);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Kullanici kullanici)
        {
            var content = new ResponseContent<Kullanici>(null);

            if (kullanici != null)
            {
                using (var kullaniciBusiness = new KullaniciBusiness())
                {
                    content.Result = kullaniciBusiness.KullaniciGuncelle(kullanici) ? "1" : "0";

                    return new StandartResult<Kullanici>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Kullanici>(content, Request);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<Kullanici>(null);

            using (var kullaniciBusiness = new KullaniciBusiness())
            {
                content.Result = kullaniciBusiness.KullaniciSilById(id) ? "1" : "0";

                return new StandartResult<Kullanici>(content, Request);
            }
        }
    }
}
