using Microsoft.Practices.ServiceLocation;
using Microsoft.Practices.Unity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using IRepositories;
using UnityBootstrapper;
using Unity.WebApi;

namespace JQueryWebApiDemo
{
    public class UnityConfig
    {
        public static void RegisterComponents(HttpConfiguration config)
        {
            var container = new UnityContainer();
            ContainerBootstrapper.Initialise(container);
            config.DependencyResolver = new UnityDependencyResolver(container);
            container.Resolve<ITaskRepository>();
            container.Resolve<IUserRepository>();
            ServiceLocator.SetLocatorProvider(() => new UnityServiceLocator(container));

        }
    }
}