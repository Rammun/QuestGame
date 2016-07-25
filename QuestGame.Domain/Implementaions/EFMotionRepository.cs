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
    public class EFMotionRepository : IMotionRepository
    {
        ApplicationDbContext dbContext;

        public EFMotionRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Motion> GetAll()
        {
            return dbContext.Transitions;
        }

        public Motion GetById(int id)
        {
            return dbContext.Transitions.Find(id);
        }

        public void Add(Motion transition)
        {
            dbContext.Transitions.Add(transition);
        }

        public void Update(Motion transition)
        {
            dbContext.Entry(transition).State = EntityState.Modified;
        }

        public void Delete(Motion transition)
        {
            Delete(transition.Id);
        }

        public void Delete(object id)
        {
            Motion transition = GetById((int)id);
            if (transition != null)
                dbContext.Transitions.Remove(transition);
        }
    }
}
