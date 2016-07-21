using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using QuestGame.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace QuestGame.Domain.DBInitializers
{
    public class InitQuests : IInitialization
    {
        public void Initialization(ApplicationDbContext dbContext)
        {
            var owner = dbContext.Users.FirstOrDefault(x => x.UserName == "admin@admin.com");

            for(int i = 0; i < 4; i++)
            {
                var quest = new Quest
                {
                    Title = "Title" + 1,
                    Date = DateTime.Now,
                    Owner = owner,
                    Frames = new List<Frame>
                    {
                        new Frame { Title = "title-1 - " + i },
                        new Frame { Title = "title-2 - " + i },
                        new Frame { Title = "title-3 - " + i },
                    }
                };
                dbContext.Quests.Add(quest);
            }
        }

    }
}
