using AutoMapper;
using Microsoft.Owin;
using Ninject;
using Ninject.Web.Common.OwinHost;
using Ninject.Web.WebApi.OwinHost;
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

            HttpConfiguration httpConfiguration = new HttpConfiguration();
            WebApiConfig.Register(httpConfiguration);

            app.UseNinjectMiddleware(CreateKernel).UseNinjectWebApi(httpConfiguration);
        }

        private static StandardKernel CreateKernel()
        {
            var kernel = new StandardKernel();
            kernel.Load(Assembly.GetExecutingAssembly());

            kernel.Bind<IApplicationDbContext>().To<ApplicationDbContext>();
            kernel.Bind<IDataManager>().To<DataManager>();
            kernel.Bind<IMapper>().ToConstant(AutoMapperConfiguration.CreatetMappings());
            kernel.Bind<ILoggerService>().To<LoggerService>();
            kernel.Bind<IQuestRepository>().To<EFQuestRepository>();

            return kernel;
        }
    }
}
