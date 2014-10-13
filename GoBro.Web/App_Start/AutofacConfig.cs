using Autofac;
using Autofac.Integration.Mvc;
using CommonServiceLocator.AutofacAdapter.Unofficial;
using GoBro.Core.Autofac;
using GoBro.Web.Autofac;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace GoBro.Web
{
    public class AutofacConfig
    {
        static IContainer container;

        public static void ConfigureContainer()
        {
            var builder = new ContainerBuilder();

            builder.RegisterModule<CoreModule>();
            builder.RegisterModule<WebModule>();

            //CommonServiceLocator is used by MediatR
            var lazy = new Lazy<IServiceLocator>(() => new AutofacServiceLocator(container));
            var serviceLocatorProvider = new ServiceLocatorProvider(() => lazy.Value);
            builder.RegisterInstance(serviceLocatorProvider);

            // Set the dependency resolver to be Autofac.
            container = builder.Build();
            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}