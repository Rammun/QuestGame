using AutoMapper;
using Microsoft.Owin.Logging;
using Ninject;
using Ninject.Modules;
using Ninject.Syntax;
using QuestGame.Common;
using QuestGame.Common.Interfaces;
using QuestGame.Domain;
using QuestGame.Domain.Implementaions;
using QuestGame.Domain.Interfaces;
using QuestGame.WebApi.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http.Dependencies;

namespace QuestGame.WebApi.Infrastructure
{
    public class NinjectDependencyScope : IDependencyScope
    {
        private IResolutionRoot resolver;

        internal NinjectDependencyScope(IResolutionRoot resolver)
        {
            //Contract.Assert(resolver != null);

            this.resolver = resolver;
        }

        public void Dispose()
        {
            var disposable = this.resolver as IDisposable;
            if (disposable != null)
            {
                disposable.Dispose();
            }

            this.resolver = null;
        }

        public object GetService(Type serviceType)
        {
            if (this.resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has already been disposed");
            }

            return this.resolver.TryGet(serviceType);
        }

        public IEnumerable<object> GetServices(Type serviceType)
        {
            if (this.resolver == null)
            {
                throw new ObjectDisposedException("this", "This scope has already been disposed");
            }

            return this.resolver.GetAll(serviceType);
        }
    }

    public class NinjectDependencyResolver : NinjectDependencyScope, IDependencyResolver, System.Web.Mvc.IDependencyResolver
    {
        private readonly IKernel kernel;

        public NinjectDependencyResolver(IKernel kernel)
            : base(kernel)
        {
            this.kernel = kernel;
        }

        public IDependencyScope BeginScope()
        {
            return new NinjectDependencyScope(this.kernel.BeginBlock());
        }
    }

    public class NinjectRegistrations : NinjectModule
    {
        public override void Load()
        {
            // Bind<IMyService>().To<MyService>().InSingletonScope();
            Bind<IApplicationDbContext>().To<ApplicationDbContext>();
            Bind<IDataManager>().To<DataManager>();
            Bind<IQuestRepository>().To<EFQuestRepository>();
            Bind<IMapper>().ToMethod(AutoMapperConfiguration.CreatetMappings());
            Bind<ILoggerService>().To<LoggerService>();

        }
    }
}