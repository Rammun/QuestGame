using AutoMapper;
using QuestGame.Common;
using QuestGame.Common.Interfaces;
using QuestGame.Domain;
using QuestGame.Domain.DTO;
using QuestGame.Domain.DTO.RequestDTO;
using QuestGame.Domain.DTO.ResponseDTO;
using QuestGame.Domain.Entities;
using QuestGame.Domain.Implementaions;
using QuestGame.Domain.Interfaces;
using QuestGame.WebApi.Infrastructure;
using QuestGame.WebApi.Mapping;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace QuestGame.WebApi.Controllers
{
    [Authorize]
    [RoutePrefix("api/Quest")]
    public class QuestController : ApiController
    {
        IDataManager dataManager;
        IMapper mapper;
        ILoggerService logger;

        public QuestController(IDataManager dataManager, IMapper mapper, ILoggerService logger)
        {
            this.dataManager = dataManager;
            this.mapper = mapper;
            this.logger = logger;
        }        

        // GET api/Quest
        public IEnumerable<QuestDTO> Get()
        {
            logger.Information("Запрос на получение всех квестов");

            var quests = dataManager.Quests.GetAll();

            var response = mapper.Map<IEnumerable<Quest>, IEnumerable<QuestDTO>>(quests.ToList());
            return response;
        }

        // GET api/Quest/5
        public QuestDTO Get(int id)
        {
            logger.Information("Запрос на получение квеста id = {0}", id);

            var quest = dataManager.Quests.GetById(id);
            if (quest == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var response = mapper.Map<Quest, QuestDTO>(quest);
            return response;
        }

        [Route("QuestsByOwner")]
        public IEnumerable<QuestDTO> GetQuestsByOwnerName(string name)
        {
            var quests = dataManager.Quests.GetQuestsByOwnerName(name);
            if (quests == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            var response = mapper.Map<IEnumerable<Quest>, IEnumerable<QuestDTO>>(quests.ToList());
            return response;
        }

        // POST api/Quest
        public IHttpActionResult Post(QuestDTO quest)
        {
            var model = mapper.Map<QuestDTO, Quest>(quest);

            var owner = dataManager.Users.FirstOrDefault(u => u.UserName == quest.Owner);
            if (owner == null)
                throw new HttpResponseException(HttpStatusCode.BadRequest);

            model.Author = owner;
            model.Date = DateTime.Now;

            try
            {
                dataManager.Quests.Add(model);
                dataManager.Save();
                return Ok();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        // PUT api/Quest
        public void Put(QuestDTO quest)
        {

        }

        // DELETE api/Quest/DelById/5
        [HttpDelete]
        [Route("DelById")]
        public IHttpActionResult DelById(int id)
        {
            try
            {
                dataManager.Quests.Delete(id);
                dataManager.Save();
                return Ok();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }

        }

        // DELETE api/Quest/DelByTitle/title
        [HttpDelete]
        [Route("DelByTitle")]
        public IHttpActionResult DelByTitle(string title)
        {
            try
            {
                dataManager.Quests.DelByTitle(title);
                dataManager.Save();
                return Ok();
            }
            catch
            {
                throw new HttpResponseException(HttpStatusCode.BadRequest);
            }
        }

        protected override void Dispose(bool disposing)
        {
            dataManager.Dispose();
            base.Dispose(disposing);
        }
    }
}
