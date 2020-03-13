using Microsoft.Extensions.DependencyInjection;
using RankCSS.Infra.Data.EF;
using System;
using System.Collections.Generic;
using System.Text;

namespace RankCSS.CrossCutting.IoC.Config
{
    public class NativeInjectorBootStrapper
    {
        public static IServiceCollection Registered { get; private set; }

        public static void RegisterServices(IServiceCollection services)
        {
            services.AddScoped<RankContext>();

            Registered = services;
        }
    }
}
