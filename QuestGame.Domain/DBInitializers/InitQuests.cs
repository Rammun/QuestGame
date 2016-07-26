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
    //public class InitQuests : IInitialization
    //{
    //    static Random rnd = new Random();

    //    public void Initialization(ApplicationDbContext dbContext)
    //    {
    //        var owner = dbContext.Users.FirstOrDefault(x => x.UserName == "admin@admin.com");

    //        for(int i = 0; i < 4; i++)
    //        {
    //            var quest = new Quest
    //            {
    //                Title = "Title" + 1,
    //                Date = DateTime.Now,
    //                Owner = owner,
    //                Stages = new List<Stage>
    //                {
    //                    new Stage { Title = "title-1 - " + i },
    //                    new Stage { Title = "title-2 - " + i },
    //                    new Stage { Title = "title-3 - " + i },
    //                }
    //            };

    //            for(int j = 0; j < quest.Stages.Count; j++)
    //            {
    //                var frame = quest.Stages.ElementAt(j);
    //                frame.Motions = new List<Motion>()
    //                {
    //                    new Motion
    //                    {
    //                        Description = "description" + j,
    //                        NextStage = quest.Stages.ElementAt(rnd.Next(0, 3))
    //                    },
    //                    new Motion
    //                    {
    //                        Description = "description" + j,
    //                        NextStage = quest.Stages.ElementAt(rnd.Next(0, 3))
    //                    },
    //                    new Motion
    //                    {
    //                        Description = "description" + j,
    //                        NextStage = quest.Stages.ElementAt(rnd.Next(0, 3))
    //                    }
    //                };
    //            }                
                
    //            dbContext.Quests.Add(quest);
    //        }
    //    }

    //}
}
