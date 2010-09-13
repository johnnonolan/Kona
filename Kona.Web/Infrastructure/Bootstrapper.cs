using Kona;
using Kona.App.Services;
using NHibernate;
using StructureMap;
using StructureMap.Configuration.DSL;
using System.Web.Mvc;

namespace Commerce.MVC.Web {
    public static class Bootstrapper {

        public static void ConfigureStructureMap() {
            //StructureMapConfiguration.AddRegistry(new StoreRegistry());
            ObjectFactory.Initialize(x => x.AddRegistry(new StoreRegistry()));
           // ControllerBuilder.Current.SetControllerFactory(new DependencyControllerFactory());
        }
    }

    public class StoreRegistry : Registry {
        public StoreRegistry()
        {
            
            //ForRequestedType<IStoreRepository>()
            //    .TheDefaultIsConcreteType<LinqRepository>();

            ForRequestedType<ISession>()
                .TheDefault.Is.ConstructedBy(x => MvcApplication.SessionFactory.GetCurrentSession());
            ForRequestedType<IStoreService>()
              .TheDefaultIsConcreteType<StoreService>();
          
        }
    }
}
