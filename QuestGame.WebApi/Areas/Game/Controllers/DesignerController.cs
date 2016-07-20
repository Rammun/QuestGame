using AutoMapper;
using Newtonsoft.Json;
using QuestGame.Domain.DTO.RequestDTO;
using QuestGame.Domain.DTO.ResponseDTO;
using QuestGame.Domain.Entities;
using QuestGame.WebApi.Helpers;
using QuestGame.WebApi.Mapping;
using QuestGame.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuestGame.WebApi.Areas.Game.Controllers
{
    public class DesignerController : Controller
    {
        IMapper mapper;

        public DesignerController()
        {
            this.mapper = AutoMapperConfiguration.CreatetMappings();
        }

        // GET: Game/Designer
        public async Task<ActionResult> Index()
        {           
            using (HttpClient client = new HttpClient())
            {
                var model = new List<QuestViewModel>();

                var user = Session["User"] as UserModel;
                if (user == null)
                {
                    ViewBag.Message = "Пользователь не аутентифицирован!";
                }
                else
                {
                    RequestHelper.ClientSetting(client, user.Token);

                    var response = await client.GetAsync(@"api/Quest");

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        ViewBag.Message = "Неудачный запрос!";
                    }
                    else
                    {
                        var answer = await response.Content.ReadAsAsync<IEnumerable<QuestResponseDTO>>();

                        foreach(var item in answer)
                        {
                            var body = JsonConvert.DeserializeObject<Quest>(item.Body);
                            model.Add(new QuestViewModel
                            {
                                Title = body.Name,
                                Owner = body.Author,
                                Date = item.Date
                            });
                        }                        
                    }                                      
                }
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult AddQuest()
        {
            var model = "Title";
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddQuest(string title)
        {
            if (title == null)
                return View();

            var user = Session["User"] as UserModel;

            var quest = new Quest
            {
                Author = user.UserName,
                Frames = new List<Frame>(),
                Name = title
            };

            var request = new QuestRequestDTO
            {
                Owner = user.UserName,
                Body = JsonConvert.SerializeObject(quest)
            };

            using (var client = new HttpClient())
            {
                RequestHelper.ClientSetting(client, user.Token);
                var response = await client.PostAsJsonAsync(@"api/Quest", request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    ViewBag.Message = "Неудачный запрос!";
                    return View();
                }
            }

            return RedirectToAction("Index");
        }
    }
}