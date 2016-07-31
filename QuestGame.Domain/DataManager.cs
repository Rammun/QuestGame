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
    public class DataManager : IDataManager, IDisposable
    {
        IApplicationDbContext dbContext;
        IQuestRepository quest;
        IStageRepository stage;
        IMotionRepository motion;

        public DataManager(IApplicationDbContext dbContext,
                           IQuestRepository quest,
                            IStageRepository stage,
                            IMotionRepository motion)
        {
            this.dbContext = dbContext;
            this.quest = quest;
            this.stage = stage;
            this.motion = motion;
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

        public IStageRepository Stages
        {
            get
            {
                if (stage == null)
                    throw new NullReferenceException("Stages равен NULL");

                return stage;
            }
        }

        public IMotionRepository Motions
        {
            get
            {
                if (motion == null)
                    throw new NullReferenceException("Motions равен NULL");

                return motion;
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
