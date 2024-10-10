using Domain.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Infrastature.Repositories;

namespace Infrastature
{
    public static class InfrastucturRegistration
    {
        public static IServiceCollection AddInfrastructuerservices(this IServiceCollection services)
        {

            services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
            services.AddScoped<IStaffRepository, StaffRepository>();
          
            return services;

        }
    }
}
