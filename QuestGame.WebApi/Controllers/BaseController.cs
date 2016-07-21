using AutoMapper;
using QuestGame.WebApi.Attributes;
using QuestGame.WebApi.Mapping;
using QuestGame.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace QuestGame.WebApi.Controllers
{
    [CustomAuthorize]
    public class BaseController : Controller
    {
        protected IMapper mapper;

        public BaseController()
        {
            this.mapper = AutoMapperConfiguration.CreatetMappings();          
        }

        protected UserModel SessionUser
        {
            get
            {
                return Session["User"] as UserModel;
            }
        }
    }
}