using QuestGame.Domain;
using QuestGame.Domain.Entities;
using QuestGame.Domain.Implementaions;
using QuestGame.WebApi.Helpers;
using QuestGame.WebApi.Models;
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
    public class DesignerController : Controller
    {
        // GET: Game/Designer
        public async Task<ActionResult> Index()
        {
            using (HttpClient client = new HttpClient())
            {
                RequestHelper.Setting(client);
                var response = await client.PostAsJsonAsync(@"api/Quest", (Session["User"] as UserModel).UserName);

                if (response.StatusCode == HttpStatusCode.BadRequest)
                {
                    ViewBag.ErrorMessage = "Неудачная запрос!";
                    return View();
                }

                var answer = await response.Content.ReadAsAsync<IEnumerable<Quest>>();

                return View(answer);
            }
        }
    }
}