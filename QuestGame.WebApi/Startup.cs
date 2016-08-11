using AutoMapper;
using Microsoft.Owin;
using Ninject;
using Owin;
using QuestGame.Common;
using QuestGame.Common.Interfaces;
using QuestGame.Domain;
using QuestGame.Domain.Implementaions;
using QuestGame.Domain.Interfaces;
using QuestGame.WebApi.Infrastructure;
using QuestGame.WebApi.Mapping;
using System.Reflection;
using System.Web.Http;

[assembly: OwinStartup(typeof(QuestGame.WebApi.Startup))]

namespace QuestGame.WebApi
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
