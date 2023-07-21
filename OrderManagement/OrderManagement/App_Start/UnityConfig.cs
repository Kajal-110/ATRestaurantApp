using OrderManagement.Repositories.Repos;
using OrderManagement.Repositories.Services;
using System.Web.Mvc;
using Unity;
using Unity.Mvc5;

namespace OrderManagement
{
    public static class UnityConfig
    {
        public static void RegisterComponents()
        {
			var container = new UnityContainer();
            container.RegisterType<IAuthService, AuthService>();
            container.RegisterType<IOrderManage, OrderManage>();
            // register all your components with the container here
            // it is NOT necessary to register your controllers

            // e.g. container.RegisterType<IAuthService, TestService>();

            DependencyResolver.SetResolver(new UnityDependencyResolver(container));
        }
    }
}