using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestGame.Domain.Entities;

namespace QuestGame.Domain.Interfaces
{
    public interface IDataManager : IDisposable
    {
        IQuestRepository Quests { get; }
        IStageRepository Stages { get; }
        IMotionRepository Motions { get; }
        IDbSet<ApplicationUser> Users { get; }
        IDbSet<IdentityRole> Roles { get; }

        void Save();
    }
}
