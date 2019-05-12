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
    public class KiralikController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            using (var kiralikBusiness = new KiralikBusiness())
            {
                List<Kiralik> kiralikList = kiralikBusiness.SelectAllKiralik();
                
                var content = new ResponseContent<Kiralik>(kiralikList);
                return new StandartResult<Kiralik>(content, Request);
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            ResponseContent<Kiralik> content;

            using (var kiralikBusiness = new KiralikBusiness())
            {
                List<Kiralik> kiralikList = null;
                try
                {
                    var temp = kiralikBusiness.KiralikSecById(id);
                    if (temp != null)
                    {
                        kiralikList = new List<Kiralik>();
                        kiralikList.Add(temp);
                    }

                    content = new ResponseContent<Kiralik>(kiralikList);
                    return new StandartResult<Kiralik>(content, Request);
                }
                catch (Exception)
                {
                    content = new ResponseContent<Kiralik>(null);
                    return new StandartResult<Kiralik>(content, Request);
                }
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Kiralik kiralik)
        {
            var content = new ResponseContent<Kiralik>(null);
            if (kiralik != null)
            {
                using (var kiralikBusiness = new KiralikBusiness())
                {
                    content.Result = kiralikBusiness.AracKirala(kiralik) ? "1" : "0";

                    return new StandartResult<Kiralik>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Kiralik>(content, Request);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Kiralik kiralik)
        {
            var content = new ResponseContent<Kiralik>(null);

            if (kiralik != null)
            {
                using (var kiralikBusiness = new KiralikBusiness())
                {
                    content.Result = kiralikBusiness.KiralikGuncelle(kiralik) ? "1" : "0";

                    return new StandartResult<Kiralik>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Kiralik>(content, Request);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<Kiralik>(null);

            using (var kiralikBusiness = new KiralikBusiness())
            {
                content.Result = kiralikBusiness.KiralikSilById(id) ? "1" : "0";

                return new StandartResult<Kiralik>(content, Request);
            }
        }
    }
}
