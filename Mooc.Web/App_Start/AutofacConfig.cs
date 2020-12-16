using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using Mooc.Core.IDependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web.Compilation;
using System.Web.Http;
using System.Web.Mvc;

namespace Mooc.Web.App_Start
{
    public class AutofacConfig
    {
        /// <summary>
        /// 负责调用autofac框架实现业务逻辑层和数据仓储层程序集中的类型对象的创建
        /// 负责创建MVC控制器类的对象(调用控制器中的有参构造函数),接管DefaultControllerFactory的工作
        /// </summary>
        public static void Register()
        {
            var builder = new ContainerBuilder();
            var config = GlobalConfiguration.Configuration;
            var baseType = typeof(IDependency);
            //builder.RegisterType<DataContext>().AsSelf().InstancePerLifetimeScope();
            var assemblys = BuildManager.GetReferencedAssemblies().Cast<Assembly>();
            List<string> inAssemblys = new List<string>() { "Mooc.Core", "Mooc.DataAccess", "Mooc.Models", "Mooc.Dtos", "Mooc.Shared", "Mooc.Utils","Mooc.Web","Mooc.Services" };
       
            var aslist = assemblys.Where(p => inAssemblys.Contains(p.FullName.Split(new char[] { ','}, StringSplitOptions.RemoveEmptyEntries)[0]));
             //aslist = assemblys.ToArray();
            builder.RegisterAssemblyTypes(aslist.ToArray()).Where(t => baseType.IsAssignableFrom(t) && t != baseType).AsImplementedInterfaces().InstancePerLifetimeScope();

           // builder.RegisterType<SSS>().As<ISSSS>().InstancePerLifetimeScope();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());
            builder.RegisterApiControllers(Assembly.GetExecutingAssembly());
            var container = builder.Build();
            config.DependencyResolver = new AutofacWebApiDependencyResolver(container);
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}