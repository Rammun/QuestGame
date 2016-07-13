using AutoMapper;
using QuestGame.Common.Interfaces;
using QuestGame.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuestGame.WebApi.Controllers
{
    [RoutePrefix("api/Values")]
    public class ValuesController
    {
        IDataManager dataManager;
        IMapper mapper;
        ILoggerService logger;

        public ValuesController(IDataManager dataManager,
                                IMapper mapper,
                                ILoggerService logger)
        {
            this.dataManager = dataManager;
            this.mapper = mapper;
            this.logger = logger;
        }

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
