using Newtonsoft.Json;
using QuestGame.Domain.DTO.RequestDTO;
using QuestGame.Domain.DTO.ResponseDTO;
using QuestGame.WebApi.Helpers;
using QuestGame.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Configuration;
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
            var model = new RegisterViewModel();
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Register(RegisterViewModel model)
        {
            if(!ModelState.IsValid)
            {
                View(model);
            }

            var registerDTO = new RegisterRequestDTO
            {
                Login = model.Email,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword
            };

            using(HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["BaseUrl"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync(@"api/Account/Register", registerDTO);
                var answer = await response.Content.ReadAsAsync<ResponseDTO>();

                if (answer.Success)
                {
                    ViewBag.ErrorMessage = "Пользователь успешно зарегистрирован!";
                }
                else
                {
                    ViewBag.ErrorMessage = "Ошибка регистрации!";
                }

                return RedirectToAction("Index");
            }            
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

            using (HttpClient client = new HttpClient())
            {
                client.BaseAddress = new Uri(WebConfigurationManager.AppSettings["BaseUrl"]);
                client.DefaultRequestHeaders.Accept.Clear();
                client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));

                var response = await client.PostAsJsonAsync(@"api/Account/LoginUser", model);
                var answer = await response.Content.ReadAsStringAsync();

                response.StatusCode == HttpStatusCode.BadRequest

                if(string.IsNullOrEmpty(answer))
                {
                    ViewBag.ErrorMessage = "Неудачная попытка аутентификации!";
                    return View();
                }

                //Записать токен в сесию
                Session["User"] = new { UserName = model.Email, Token = answer };

                return View("Index");
            }
        }
    }
}
