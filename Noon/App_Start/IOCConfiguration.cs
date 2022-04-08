using Autofac;
using Autofac.Integration.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Repository;
using Data;
using System.Web.Mvc;

namespace Noon.App_Start
{
    public class IOCConfiguration
    {
        public static void IOCConfiguer()
        {
            var Builder = new ContainerBuilder();
            Builder.RegisterControllers(typeof(MvcApplication).Assembly);
            Builder.RegisterType<UnitOfWork>().As<IUnitOfWork>();
            Builder.RegisterGeneric(typeof(MainRepository<>)).As(typeof(IRepository<>));
            Builder.RegisterType<ContextFactory>().As<IContextFactory>().SingleInstance();

            IContainer container = Builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}