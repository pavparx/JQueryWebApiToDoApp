using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Repos;
using IRepositories;
using Microsoft.Practices.Unity;
using Microsoft.Practices.Unity.Configuration;
using System.Configuration;

namespace UnityBootstrapper
{

    public static class ContainerBootstrapper
    {
        public static void Initialise(IUnityContainer container)
        {
            container.RegisterType<ITaskRepository, TaskRepository>();
            container.RegisterType<IUserRepository, UserRepository>();
        }
    }
}
