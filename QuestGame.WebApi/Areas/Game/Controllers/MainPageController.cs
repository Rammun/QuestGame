using QuestGame.WebApi.Attributes;
using QuestGame.WebApi.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestGame.WebApi.Areas.Game.Controllers
{
    public class MainPageController : BaseController
    {
        // GET: Game/MainPage
        public ActionResult Index()
        {
            return View();
        }
    }
}