using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestGame.Domain.Entities;
using Microsoft.AspNet.Identity.EntityFramework;

namespace QuestGame.Domain.Interfaces
{
    public interface IApplicationDbContext
    {
        DbSet<Quest> Quests { get; set; }
        DbSet<Stage> Stages { get; set; }
        DbSet<Motion> Motions { get; set; }

        IDbSet<ApplicationUser> GetUsers();
        IDbSet<IdentityRole> GetRoles();

        void SaveChanges();
        void EntryObj<T>(T entity) where T : class;
        void Dispose();
    }
}
