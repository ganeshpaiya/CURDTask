using Application.Common;
using Application.Services;
using Application.Services.Interface;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application
{
    public static class ApplicationRegistration
    {
        public static IServiceCollection ApplicationServices(this IServiceCollection services)
        {
            services.AddAutoMapper(typeof(MappingProfile));
            services.AddScoped<IStaffSetrvices, StaffSetrvices>();
          
            return services;
        }
    }
}
