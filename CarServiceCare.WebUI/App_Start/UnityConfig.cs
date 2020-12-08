using CarServiceCare.Core.Contracts;
using CarServiceCare.Core.Models;
using System;
using CarServiceCare.DataAccess.InMemory;

using Unity;
using CarServiceCare.DataAccess.SQL;

namespace CarServiceCare.WebUI
{
    /// <summary>
    /// Specifies the Unity configuration for the main container.
    /// </summary>
    public static class UnityConfig
    {
        #region Unity Container
        private static Lazy<IUnityContainer> container =
          new Lazy<IUnityContainer>(() =>
          {
              var container = new UnityContainer();
              RegisterTypes(container);
              return container;
          });

        /// <summary>
        /// Configured Unity Container.
        /// </summary>
        public static IUnityContainer Container => container.Value;
        #endregion

        /// <summary>
        /// Registers the type mappings with the Unity container.
        /// </summary>
        /// <param name="container">The unity container to configure.</param>
        /// <remarks>
        /// There is no need to register concrete types such as controllers or
        /// API controllers (unless you want to change the defaults), as Unity
        /// allows resolving a concrete type even if it was not previously
        /// registered.
        /// </remarks>
        public static void RegisterTypes(IUnityContainer container)
        {
            // NOTE: To load from web.config uncomment the line below.
            // Make sure to add a Unity.Configuration to the using statements.
            // container.LoadConfiguration();

            // TODO: Register your type's mappings here.
            // container.RegisterType<IProductRepository, ProductRepository>();

            //Register type's

            //store data inMemory or in DB
            bool inMemory = true;

            if (inMemory)
            {
                container.RegisterType<IRepository<Car>, InMemoryRepository<Car>>();
                container.RegisterType<IRepository<CarInsurance>, InMemoryRepository<CarInsurance>>();
                container.RegisterType<IRepository<Expense>, InMemoryRepository<Expense>>();
                container.RegisterType<IRepository<Refueling>, InMemoryRepository<Refueling>>();
                container.RegisterType<IRepository<Repair>, InMemoryRepository<Repair>>();
                container.RegisterType<IRepository<Service>, InMemoryRepository<Service>>();
                container.RegisterType<IRepository<STK>, InMemoryRepository<STK>>();
                container.RegisterType<IRepository<TireChange>, InMemoryRepository<TireChange>>();
                container.RegisterType<IRepository<User>, InMemoryRepository<User>>();
            }
            else
            {
                container.RegisterType<IRepository<Car>, SQLRepository<Car>>();
                container.RegisterType<IRepository<CarInsurance>, SQLRepository<CarInsurance>>();
                container.RegisterType<IRepository<Expense>, SQLRepository<Expense>>();
                container.RegisterType<IRepository<Refueling>, SQLRepository<Refueling>>();
                container.RegisterType<IRepository<Repair>, SQLRepository<Repair>>();
                container.RegisterType<IRepository<Service>, SQLRepository<Service>>();
                container.RegisterType<IRepository<STK>, SQLRepository<STK>>();
                container.RegisterType<IRepository<TireChange>, SQLRepository<TireChange>>();
                container.RegisterType<IRepository<User>, SQLRepository<User>>();
            }

        }
    }
}