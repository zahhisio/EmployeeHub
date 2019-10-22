using Autofac;
using Autofac.Integration.Mvc;
using Autofac.Integration.WebApi;
using EmployeeHub.DAL;
using EmployeeHub.Services;
using System.Web.Http;
using System.Web.Mvc;

namespace EmployeeHub.Web.App_Start
{
    public class ContainerConfig
    {
        internal static void RegisterContainer(HttpConfiguration httpConfiguration)
        {
            var builder = new ContainerBuilder();
            builder.RegisterApiControllers(typeof(MvcApplication).Assembly);
            builder.RegisterControllers(typeof(MvcApplication).Assembly);
            builder.RegisterType<ISql>()
                .As<IEmployeeData>()
                .SingleInstance();
            builder.RegisterType<EmployeeListDbContext>().InstancePerLifetimeScope();

            var container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
            httpConfiguration.DependencyResolver = new AutofacWebApiDependencyResolver(container);
        }
    }
}