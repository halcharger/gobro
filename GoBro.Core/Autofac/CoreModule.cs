using Autofac;
using GoBro.Core.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace GoBro.Core.Autofac
{
    public class CoreModule : Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterAssemblyTypes(typeof (CoreModule).Assembly).AsImplementedInterfaces();

            builder.RegisterType<GoBroAzureTables>();
        }
    }
}
