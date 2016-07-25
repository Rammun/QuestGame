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
        ApplicationDbContext dbContext;

        public EFStageRepository(ApplicationDbContext dbContext)
        {
            dbContext = this.dbContext;
        }

        public IEnumerable<Stage> GetAll()
        {
            return dbContext.Frames;
        }

        public Stage GetById(int id)
        {
            return dbContext.Frames.Find(id);
        }

        public void Add(Stage frame)
        {
            dbContext.Frames.Add(frame);
        }

        public void Update(Stage frame)
        {
            dbContext.Entry(frame).State = EntityState.Modified;
        }

        public void Delete(Stage frame)
        {
            Delete(frame.Id);
        }

        public void Delete(object id)
        {
            Stage frame = GetById((int)id);
            if (frame != null)
                dbContext.Frames.Remove(frame);
        }
    }
}
