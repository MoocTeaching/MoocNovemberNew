using Autofac;
using Mooc.Services.Interfaces;
using Mooc.Web.App_Start;

using System.Linq;
using System.Reflection;

namespace Mooc.Web.Tests
{
    public static class UTestConfigHelper
    {
        static IContainer _build;
        static UTestConfigHelper()
        {
            var builder = new ContainerBuilder();
            var baseType = typeof(IDependency);
            //builder.RegisterType<DataContext>().AsSelf().InstancePerLifetimeScope();
            //var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            var assemblys = new Assembly[] { baseType.Assembly };
            builder.RegisterAssemblyTypes(assemblys.ToArray()).Where(t => baseType.IsAssignableFrom(t) && t != baseType).AsImplementedInterfaces().InstancePerLifetimeScope();
            //builder.RegisterType<DataContextProviderTest>().As<IDataContextProvider>().InstancePerLifetimeScope();
            _build = builder.Build();

            AutoMapperConfig.Config();
        }

        public static T ResolveServcie<T>()
        {
            if (_build == null)
                return default(T);

            return _build.Resolve<T>();
        }
    }
}
