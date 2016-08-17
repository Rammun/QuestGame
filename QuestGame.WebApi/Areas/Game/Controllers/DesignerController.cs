﻿using QuestGame.Domain.DTO;
using QuestGame.WebApi.Areas.Game.Models;
using QuestGame.WebApi.Controllers;
using QuestGame.WebApi.Helpers;
using System.Collections.Generic;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web.Mvc;

namespace QuestGame.WebApi.Areas.Game.Controllers
{
    public class DesignerController : BaseController
    {
        // GET: Game/Designer
        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                RequestHelper.ClientSetting(client, SessionUser.Token);

                var response = await client.GetAsync(@"api/Quest/QuestsByOwner?name=" + SessionUser.UserName);

                IEnumerable<QuestViewModel> model = null;
                if (response.StatusCode != HttpStatusCode.OK)
                {
                    ViewBag.Message = "Неудачный запрос!";
                }
                else
                {
                    var answer = await response.Content.ReadAsAsync<IEnumerable<QuestDTO>>();

                    model = mapper.Map<IEnumerable<QuestDTO>, IEnumerable<QuestViewModel>>(answer);            
                }                                      
                
                return View(model);
            }
        }

        [HttpGet]
        public ActionResult AddQuest()
        {
            var model = new NewQuestViewModel
            {
                Title = "Title",
                Owner = SessionUser.UserName
            };

            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> AddQuest(NewQuestViewModel model)
        {
            if (!ModelState.IsValid)
                return View(model);

            var request = mapper.Map<NewQuestViewModel, QuestDTO>(model);

            using (var client = new HttpClient())
            {
                RequestHelper.ClientSetting(client, SessionUser.Token);
                var response = await client.PostAsJsonAsync(@"api/Quest", request);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    ViewBag.Message = "Не удалось добавить квест!";
                    return View(model);
                }
            }

            return RedirectToAction("Index", "Designer");
        }

        [HttpGet]
        public async Task<ActionResult> DeleteQuest(string title)
        {
            if (title == null)
                return View(title);

            using (var client = new HttpClient())
            {
                RequestHelper.ClientSetting(client, SessionUser.Token);
                var response = await client.DeleteAsync(@"api/Quest/DelByTitle?title=" + title);

                if (response.StatusCode != HttpStatusCode.OK)
                {
                    ViewBag.Message = "Не удалось добавить квест!";
                }
            }

            return RedirectToAction("Index", "Designer");
        }
    }
}