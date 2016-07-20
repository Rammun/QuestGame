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
    public class EFTransitionRepository : ITransitionRepository
    {
        ApplicationDbContext dbContext;

        public EFTransitionRepository(ApplicationDbContext dbContext)
        {
            this.dbContext = dbContext;
        }

        public IEnumerable<Transition> GetAll()
        {
            return dbContext.Transitions;
        }

        public Transition GetById(int id)
        {
            return dbContext.Transitions.Find(id);
        }

        public void Add(Transition transition)
        {
            dbContext.Transitions.Add(transition);
        }

        public void Update(Transition transition)
        {
            dbContext.Entry(transition).State = EntityState.Modified;
        }

        public void Delete(Transition transition)
        {
            Delete(transition.Id);
        }

        public void Delete(object id)
        {
            Transition transition = GetById((int)id);
            if (transition != null)
                dbContext.Transitions.Remove(transition);
        }
    }
}
