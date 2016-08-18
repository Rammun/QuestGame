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
        IApplicationDbContext dbContext;

        public EFQuestRepository(IApplicationDbContext dbContext)
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

        public Quest GetByTitle(string title)
        {
            return dbContext.Quests.FirstOrDefault(x => x.Title == title);
        }

        public IEnumerable<Quest> GetQuestsByOwnerName(string name)
        {
            return dbContext.Quests.Where(x => x.Author.UserName == name);
        }

        public void Add(Quest quest)
        {
            dbContext.Quests.Add(quest);
        }

        public void Update(Quest quest)
        {
            dbContext.EntryObj<Quest>(quest);
        }

        public void Delete(Quest quest)
        {
            Delete(quest.Id);
        }

        public void DelByTitle(string title)
        {
            Delete(GetByTitle(title));
        }

        public void Delete(object id)
        {
            Quest quest = GetById((int)id);
            if (quest != null)
                dbContext.Quests.Remove(quest);
        }
    }
}
