using AutoMapper;
using QuestGame.Domain;
using QuestGame.Domain.DTO.ResponseDTO;
using QuestGame.Domain.Entities;
using QuestGame.Domain.Implementaions;
using QuestGame.WebApi.Mapping;
using System;
using System.Collections.Generic;
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
        DataManager dataManager;
        IMapper mapper;

        public QuestController()
        {
            var dbContext = new ApplicationDbContext();
            this.dataManager = new DataManager(dbContext, new EFQuestRepository(dbContext));

            mapper = AutoMapperConfiguration.GetMappings();
        }

        // GET api/values
        public IEnumerable<QuestResponseDTO> Get()
        {
            var quests = dataManager.Quests.GetAll();

            var response = mapper.Map<IEnumerable<Quest>, IEnumerable<QuestResponseDTO>>(quests);
            return response;
        }

        // GET api/values/5
        public QuestResponseDTO Get(int id)
        {
            var quest = dataManager.Quests.GetById(id);
            var response = new QuestResponseDTO
            {
                Owner = quest.Owner.UserName,
                Body = quest.Body
            };
            return response;
        }

        // POST api/values
        public void Post(Quest quest)
        {
            dataManager.Quests.Add(quest);
        }

        // DELETE api/values/5
        public void Delete(int id)
        {
            dataManager.Quests.Delete(id);
        }
    }
}
