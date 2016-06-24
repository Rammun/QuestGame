﻿using Newtonsoft.Json;
using QuestGame.Domain.DTO;
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
        IRequestHelper requestHelper;

        public HomeController()
        {
            requestHelper = new RequestHelper();
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
        public async Task<ActionResult> Register(RegisterBindingModel model)
        {
            if(!ModelState.IsValid)
            {
                View(model);
            }
            var response = await requestHelper.PostAsJsonAsync(@"api/Account/Register", model);
            var answer = await response.Content.ReadAsAsync<ResponseDTO>();

            if(answer.Success)
            {
                ViewBag.ErrorMessage = "Пользователь успешно зарегистрирован!";
            }
            else
            {
                ViewBag.ErrorMessage = "Ошибка регистрации!";
            }

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

            var response = await requestHelper.PostAsJsonAsync(@"api/Account/LoginUser", model);
            var answer = await response.Content.ReadAsAsync<HttpResponseMessage>();
            
            answer.

            return View("Index");
        }
    }
}
