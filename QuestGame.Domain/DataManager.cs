using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestGame.Domain.Entities;
using QuestGame.Domain.Implementaions;
using QuestGame.Domain.Interfaces;

namespace QuestGame.Domain
{
    public class DataManager : IDataManager
    {
        IApplicationDbContext dbContext;
        IQuestRepository quest;
        IFrameRepository frame;
        ITransitionRepository transition;

        public DataManager(IApplicationDbContext dbContext,
                           IQuestRepository quest,
                            IFrameRepository frame,
                            ITransitionRepository transition)
        {
            this.dbContext = dbContext;
            this.quest = quest;
            this.frame = frame;
            this.transition = transition;
        }

        public IQuestRepository Quests
        {
            get
            {
                if (quest == null)
                    throw new NullReferenceException("Quests равен NULL");

                return quest;
            }
        }

        public IFrameRepository Frames
        {
            get
            {
                if (frame == null)
                    throw new NullReferenceException("Frames равен NULL");

                return frame;
            }
        }

        public ITransitionRepository Transitions
        {
            get
            {
                if (transition == null)
                    throw new NullReferenceException("Transitions равен NULL");

                return transition;
            }
        }

        public IDbSet<ApplicationUser> Users
        {
            get
            {
                return dbContext.GetUsers();
            }
        }

        public IDbSet<IdentityRole> Roles
        {
            get
            {
                return dbContext.GetRoles();
            }
        }
        
        public void Save()
        {
            dbContext.SaveChanges();
        }

        private bool disposed = false;

        public virtual void Dispose(bool disposing)
        {
            if (!this.disposed)
            {
                if (disposing)
                {
                    dbContext.Dispose();
                }
                this.disposed = true;
            }
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
    }
}
