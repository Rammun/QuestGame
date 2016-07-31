using QuestGame.Domain.Entities;
using QuestGame.Domain.Interfaces;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.Implementaions
{
    public class EFStageRepository : IStageRepository
    {
        IApplicationDbContext dbContext;

        public EFStageRepository(IApplicationDbContext dbContext)
        {
            dbContext = this.dbContext;
        }

        public IEnumerable<Stage> GetAll()
        {
            return dbContext.Stages;
        }

        public Stage GetById(int id)
        {
            return dbContext.Stages.Find(id);
        }

        public void Add(Stage frame)
        {
            dbContext.Stages.Add(frame);
        }

        public void Update(Stage frame)
        {
            dbContext.EntryObj<Stage>(frame);
        }

        public void Delete(Stage frame)
        {
            Delete(frame.Id);
        }

        public void Delete(object id)
        {
            Stage frame = GetById((int)id);
            if (frame != null)
                dbContext.Stages.Remove(frame);
        }
    }
}
