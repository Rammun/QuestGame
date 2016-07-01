using QuestGame.Domain;
using QuestGame.Domain.Implementaions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestGame.WebApi.Areas.Game.Controllers
{
    public class DesignerController : Controller
    {
        DataManager dataManager;

        public DesignerController()
        {
            var dbContext = new ApplicationDbContext();
            dataManager = new DataManager(dbContext, new EFQuestRepository(dbContext));
        }

        // GET: Game/Designer
        public ActionResult Index()
        {
            var quests = dataManager.Quests.GetAll().ToList();
            return View(quests);
        }
    }
}