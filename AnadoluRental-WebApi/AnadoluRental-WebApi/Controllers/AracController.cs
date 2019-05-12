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
    public class AracController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            using (var aracBusiness = new AracBusiness())
            {
                List<Arac> aracList = aracBusiness.SelectAllArac();
                
                var content = new ResponseContent<Arac>(aracList);
                return new StandartResult<Arac>(content, Request);
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            ResponseContent<Arac> content;

            using (var aracBusiness = new AracBusiness())
            {
                List<Arac> aracList = null;
                try
                {
                    var temp = aracBusiness.AracSecById(id);
                    if (temp != null)
                    {
                        aracList = new List<Arac>();
                        aracList.Add(temp);
                    }

                    content = new ResponseContent<Arac>(aracList);
                    return new StandartResult<Arac>(content, Request);
                }
                catch (Exception)
                {
                    content = new ResponseContent<Arac>(null);
                    return new StandartResult<Arac>(content, Request);
                }
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Arac arac)
        {
            var content = new ResponseContent<Arac>(null);
            if (arac != null)
            {
                using (var aracBusiness = new AracBusiness())
                {
                    content.Result = aracBusiness.AracEkle(arac) ? "1" : "0";

                    return new StandartResult<Arac>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Arac>(content, Request);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Arac arac)
        {
            var content = new ResponseContent<Arac>(null);

            if (arac != null)
            {
                using (var aracBusiness = new AracBusiness())
                {
                    content.Result = aracBusiness.AracGuncelle(arac) ? "1" : "0";

                    return new StandartResult<Arac>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Arac>(content, Request);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<Arac>(null);

            using (var aracBusiness = new AracBusiness())
            {
                content.Result = aracBusiness.AracSilById(id) ? "1" : "0";

                return new StandartResult<Arac>(content, Request);
            }
        }
    }
}
