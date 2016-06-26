using Newtonsoft.Json;
using QuestGame.WebApi.Helpers;
using QuestGame.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
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
        [ValidateAntiForgeryToken]
        public ActionResult Register(RegisterBindingModel model)
        {
            if(!ModelState.IsValid)
            {
                View(model);
            }
            var respons = request.PostAsJsonAsync<HttpResponseMessage>(@"api/Account/Register", model);

            return RedirectToAction("Index");
        }

        public ActionResult Login(string returnUrl)
        {
            ViewBag.ReturnUrl = returnUrl;
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Login(LoginViewModel model)
        {
            if (!ModelState.IsValid)
            {
                View(model);
            }

            var respons = await request.PostAsJsonAsync<HttpResponseMessage>(@"api/Account/LoginUser", model);
            //if(!respons.IsSuccessStatusCode)
            //{
            //    ViewBag.ErrorMessage = "Неудачаная попытка аутентификации";
            //    return View();
            //}

            return View("Index");
        }
    }
}
