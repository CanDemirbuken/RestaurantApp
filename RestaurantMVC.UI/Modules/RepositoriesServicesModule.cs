using Module = Autofac.Module;
using RestaurantMVC.BusinessLayer.Services;
using RestaurantMVC.Core.Repositories;
using RestaurantMVC.Core.Services;
using RestaurantMVC.Core.UnitOfWorks;
using RestaurantMVC.DataAccessLayer.Repositories;
using RestaurantMVC.DataAccessLayer.UnitOfWork;
using RestaurantMVC.DataAccessLayer;
using System.Reflection;
using Autofac;

namespace RestaurantMVC.UI.Modules
{
    public class RepositoriesServicesModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterGeneric(typeof(GenericRepository<>)).As(typeof(IGenericRepository<>)).InstancePerLifetimeScope();
            builder.RegisterGeneric(typeof(Service<>)).As(typeof(IService<>)).InstancePerLifetimeScope();

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();

            var repoAssembly = Assembly.GetAssembly(typeof(AppDbContext))!;
            var serviceAssembly = Assembly.GetAssembly(typeof(ServiceService))!;

            builder.RegisterAssemblyTypes(repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Repository")).AsImplementedInterfaces().InstancePerLifetimeScope();
            builder.RegisterAssemblyTypes(repoAssembly, serviceAssembly).Where(x => x.Name.EndsWith("Service")).AsImplementedInterfaces().InstancePerLifetimeScope();

            base.Load(builder);
        }
    }
}
