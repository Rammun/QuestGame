using Newtonsoft.Json;
using QuestGame.WebApi.Helpers;
using QuestGame.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestGame.WebApi.Controllers
{
    public class HomeController : Controller
    {
        IRequestHelper request;

        public HomeController()
        {
            request = new RequestHelper();
        }

        public ActionResult Index()
        {
            ViewBag.Title = "Home Page";

            return View();
        }

        public ActionResult Register()
        {
            var model = new RegisterBindingModel();
            return View(model);
        }

        [HttpPost]
        public ActionResult Register(RegisterBindingModel model)
        {
            if(!ModelState.IsValid)
            {
                View(model);
            }
            //var param = JsonConvert.SerializeObject(model);
            var respons = request.PostAsJson(@"api/Account/Register", model);

            return RedirectToAction("Index");
        }
    }
}
