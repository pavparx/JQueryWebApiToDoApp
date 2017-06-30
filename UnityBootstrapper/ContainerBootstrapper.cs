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

    public class ContainerBootstrapper
    {
        IUnityContainer myContainer = new UnityContainer().RegisterType<ITaskRepository, TaskRepository>();



        //private static IUnityContainer _container;

        ///// <summary>
        ///// Public reference to the unity container which will 
        ///// allow the ability to register instances or take 
        ///// other actions on the container.
        ///// </summary>
        public IUnityContainer Container
        {
            get
            {
                return myContainer;
            }
            private set
            {
                myContainer = value;
            }
        }

        ///// <summary>
        ///// Static constructor for DependencyFactory which will 
        ///// initialize the unity container.
        ///// </summary>
        //static ContainerBootstrapper()
        //{
        //    var container = new UnityContainer();

        //    var section = (UnityConfigurationSection)ConfigurationManager.GetSection("unity");
        //    if (section != null)
        //    {
        //        section.Configure(container);
        //    }
        //    _container = container;
        //}

        ///// <summary>
        ///// Resolves the type parameter T to an instance of the appropriate type.
        ///// </summary>
        ///// <typeparam name="T">Type of object to return</typeparam>
        //public static T Resolve<T>()
        //{
        //    T ret = default(T);

        //    if (Container.IsRegistered(typeof(T)))
        //    {
        //        ret = Container.Resolve<T>();
        //    }

        //    return ret;
        //}

    }
}
