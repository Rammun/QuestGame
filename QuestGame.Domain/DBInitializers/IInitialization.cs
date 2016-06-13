using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using QuestGame.Domain;
using QuestGame.Domain.Interfaces;

namespace QuestGame.Domain.DBInitializers
{
    public interface IInitialization
    {
        void Initialization(ApplicationDbContext context);
    }
}
