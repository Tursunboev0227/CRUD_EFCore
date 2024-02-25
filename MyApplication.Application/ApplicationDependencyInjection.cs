using Microsoft.Extensions.DependencyInjection;
using MyApplication.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MyApplication.Application
{
    public static class ApplicationDependencyInjection
    {
        public static IServiceCollection AddAplication(this IServiceCollection services)
        {
            services.AddScoped<IPersonServise, PersonServise>();
            return services;
        }
    }
}
