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
        DbSet<Stage> Quests { get; set; }
        DbSet<Stage> Frames { get; set; }
        DbSet<Motion> Transitions { get; set; }

        IDbSet<ApplicationUser> GetUsers();
        IDbSet<IdentityRole> GetRoles();

        void SaveChanges();
        void Dispose();
    }
}
