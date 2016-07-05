using AutoMapper;
using Newtonsoft.Json;
using QuestGame.BusinessLogic.Models;
using QuestGame.Domain.DTO.RequestDTO;
using QuestGame.Domain.DTO.ResponseDTO;
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
                IEnumerable<QuestViewModel> quests = null;

                var user = Session["User"] as UserModel;
                if (user == null)
                {
                    ViewBag.Message = "Пользователь не аутентифицирован!";
                }
                else
                {
                    RequestHelper.Setting(client);
                    client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("bearer", user.Token);

                    var response = await client.GetAsync(@"api/Quest");

                    if (response.StatusCode != HttpStatusCode.OK)
                    {
                        ViewBag.Message = "Неудачный запрос!";
                    }
                    else
                    {
                        var answer = await response.Content.ReadAsAsync<IEnumerable<QuestResponseDTO>>();
                        quests = mapper.Map<IEnumerable<QuestResponseDTO>, IEnumerable<QuestViewModel>>(answer);
                    }                                      
                }
                return View(quests);
            }
        }
    }
}