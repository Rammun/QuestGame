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
        IApplicationDbContext dbContext;

        public EFMotionRepository(IApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Motion> GetAll()
        {
            return dbContext.Motions;
        }

        public Motion GetById(int id)
        {
            return dbContext.Motions.Find(id);
        }

        public void Add(Motion transition)
        {
            dbContext.Motions.Add(transition);
        }

        public void Update(Motion transition)
        {
            dbContext.EntryObj<Motion>(transition);
        }

        public void Delete(Motion transition)
        {
            Delete(transition.Id);
        }

        public void Delete(object id)
        {
            Motion transition = GetById((int)id);
            if (transition != null)
                dbContext.Motions.Remove(transition);
        }
    }
}
