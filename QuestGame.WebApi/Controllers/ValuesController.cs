using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuestGame.WebApi.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController : ApiController
    {
        // GET api/values
        [Authorize]
        [HttpGet]
        [Route("Authorize")]
        public string Get()
        {
            return "Authorize";
        }

        // GET api/values/5
        [Authorize(Roles = "admin")]
        [HttpGet]
        [Route("Admin")]
        public string Admin()
        {
            return "Admin";
        }

        // POST api/values
        public void Post([FromBody]string value)
        {
        }

        // PUT api/values/5
        public void Put(int id, [FromBody]string value)
        {
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
        }
    }
}
