using AutoMapper;
using Ninject;
using Ninject.Activation;
using Ninject.Parameters;
using Ninject.Syntax;
using Ninject.Web.WebApi;
using QuestGame.Common;
using QuestGame.Common.Interfaces;
using QuestGame.Domain;
using QuestGame.Domain.Interfaces;
using QuestGame.WebApi.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Http;
using System.Web.Http.Dependencies;

namespace QuestGame.WebApi.Infrastructure
{
    //public static class NinjectConfig
    //{
    //    public static Lazy<IKernel> CreateKernel = new Lazy<IKernel>(() =>
    //    {
    //        var kernel = new StandardKernel();
    //        kernel.Load(Assembly.GetExecutingAssembly());

    //        RegisterServices(kernel);
    //        GlobalConfiguration.Configuration.DependencyResolver = new NinjectDependencyResolver(kernel);
    //        return kernel;
    //    });

    //    private static void RegisterServices(KernelBase kernel)
    //    {
    //        kernel.Bind<IDataManager>().To<DataManager>().WithConstructorArgument(new ApplicationDbContext());
    //        kernel.Bind<IMapper>().ToConstant(AutoMapperConfiguration.CreatetMappings());
    //        kernel.Bind<ILoggerService>().To<LoggerService>();
    //    }
    //}

    public class NinjectResolver : NinjectScope, IDependencyResolver
    {
        private readonly IKernel _kernel;
        public NinjectResolver(IKernel kernel)
            : base(kernel)
        {
            _kernel = kernel;
        }
        public IDependencyScope BeginScope()
        {
            return new NinjectScope(_kernel.BeginBlock());
        }
    }

    public class NinjectScope : IDependencyScope
    {
        protected IResolutionRoot resolutionRoot;
        public NinjectScope(IResolutionRoot kernel)
        {
            resolutionRoot = kernel;
        }
        public object GetService(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).SingleOrDefault();
        }
        public IEnumerable<object> GetServices(Type serviceType)
        {
            IRequest request = resolutionRoot.CreateRequest(serviceType, null, new Parameter[0], true, true);
            return resolutionRoot.Resolve(request).ToList();
        }
        public void Dispose()
        {
            IDisposable disposable = (IDisposable)resolutionRoot;
            if (disposable != null) disposable.Dispose();
            resolutionRoot = null;
        }
    }
}