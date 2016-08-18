using QuestGame.Domain.DTO;
using QuestGame.Domain.Interfaces;
using QuestGame.WebApi.Areas.Game.Models;
using QuestGame.WebApi.Attributes;
using QuestGame.WebApi.Controllers;
using QuestGame.WebApi.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;
using System.Web.Mvc;

namespace QuestGame.WebApi.Areas.Game.Controllers
{
    public class MainPageController : BaseController
    {
        // GET: Game/MainPage
        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                RequestHelper.ClientSetting(client, SessionUser.Token);

                var response = await client.GetAsync(@"api/Quest");

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
    }
}