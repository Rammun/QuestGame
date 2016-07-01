using QuestGame.Domain;
using QuestGame.Domain.Entities;
using QuestGame.Domain.Implementaions;
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

        public QuestController()
        {
            var dbContext = new ApplicationDbContext();
            this.dataManager = new DataManager(dbContext, new EFQuestRepository(dbContext));
        }

        // GET api/values
        public IEnumerable<Quest> Get()
        {
            return dataManager.Quests.GetAll();
        }

        // GET api/values/5
        public Quest Get(int id)
        {
            return dataManager.Quests.GetById(id);
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
