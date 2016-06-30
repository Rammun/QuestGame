using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestGame.WebApi.Areas.Game.Controllers
{
    public class MainPageController : Controller
    {
        // GET: Game/MainPage
        public ActionResult Index()
        {
            return View();
        }
    }
}