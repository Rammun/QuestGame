using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestGame.Domain.Entities;
using QuestGame.Domain.Interfaces;

namespace QuestGame.Domain.Implementaions
{
    public class EFQuestRepository : IQuestRepository
    {
        ApplicationDbContext dbContext;

        public EFQuestRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Quest> GetAll()
        {
            return dbContext.Quests;
        }

        public Quest GetById(int id)
        {
            return dbContext.Quests.Find(id);
        }

        public void Add(Quest quest)
        {
            dbContext.Quests.Add(quest);
        }

        public void Update(Quest quest)
        {
            dbContext.Entry(quest).State = EntityState.Modified;
        }

        public void Delete(Quest quest)
        {
            Delete(quest.Id);
        }

        public void Delete(object id)
        {
            Quest quest = GetById((int)id);
            if (quest != null)
                dbContext.Quests.Remove(quest);
        }
    }
}
