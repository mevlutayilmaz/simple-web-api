using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application
{
    public static class ServiceRegistration
    {
        public static void AddApplicationServices(this IServiceCollection colleciton)
        {
            colleciton.AddMediatR(typeof(ServiceRegistration));
            colleciton.AddAutoMapper(Assembly.GetExecutingAssembly());
        }
    }
}
