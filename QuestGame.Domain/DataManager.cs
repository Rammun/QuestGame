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

        //IFriendRepository friend;

        public DataManager(IApplicationDbContext dbContext,
                           ITargetUserRepository targetUser,
                           ISubscriberRepository subscriber)
        {            
            this.targetUser = targetUser;
            this.subscriber = subscriber;

            if (dbContext == null)
                throw new NullReferenceException("ApplicationDbContext равен NULL");
            this.dbContext = dbContext;
        }

        public IFriendRepository Friends
        {
            get
            {
                if (friend == null)
                    throw new NullReferenceException("Subscribers равен NULL");

                return friend;
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
