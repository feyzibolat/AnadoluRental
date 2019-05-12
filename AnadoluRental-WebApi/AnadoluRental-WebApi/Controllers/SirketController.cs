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
    public class SirketController : ApiController
    {
        // GET api/<controller>
        public IHttpActionResult Get()
        {
            using (var sirketBusiness = new SirketBusiness())
            {
                List<Sirket> sirketList = sirketBusiness.SelectAllSirket();
                
                var content = new ResponseContent<Sirket>(sirketList);
                return new StandartResult<Sirket>(content, Request);
            }
        }

        // GET api/<controller>/5
        public IHttpActionResult Get(int id)
        {
            ResponseContent<Sirket> content;

            using (var sirketBusiness = new SirketBusiness())
            {
                List<Sirket> sirketList = null;
                try
                {
                    var temp = sirketBusiness.SirketSecById(id);
                    if (temp != null)
                    {
                        sirketList = new List<Sirket>();
                        sirketList.Add(temp);
                    }

                    content = new ResponseContent<Sirket>(sirketList);
                    return new StandartResult<Sirket>(content, Request);
                }
                catch (Exception)
                {
                    content = new ResponseContent<Sirket>(null);
                    return new StandartResult<Sirket>(content, Request);
                }
            }
        }

        // POST api/<controller>
        public IHttpActionResult Post([FromBody]Sirket sirket)
        {
            var content = new ResponseContent<Sirket>(null);
            if (sirket != null)
            {
                using (var sirketBusiness = new SirketBusiness())
                {
                    content.Result = sirketBusiness.SirketEkle(sirket) ? "1" : "0";

                    return new StandartResult<Sirket>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Sirket>(content, Request);
        }

        // PUT api/<controller>/5
        public IHttpActionResult Put(int id, [FromBody]Sirket sirket)
        {
            var content = new ResponseContent<Sirket>(null);

            if (sirket != null)
            {
                using (var sirketBusiness = new SirketBusiness())
                {
                    content.Result = sirketBusiness.SirketGuncelle(sirket) ? "1" : "0";

                    return new StandartResult<Sirket>(content, Request);
                }
            }

            content.Result = "0";

            return new StandartResult<Sirket>(content, Request);
        }

        // DELETE api/<controller>/5
        public IHttpActionResult Delete(int id)
        {
            var content = new ResponseContent<Sirket>(null);

            using (var sirketBusiness = new SirketBusiness())
            {
                content.Result = sirketBusiness.SirketSilById(id) ? "1" : "0";

                return new StandartResult<Sirket>(content, Request);
            }
        }
    }
}
