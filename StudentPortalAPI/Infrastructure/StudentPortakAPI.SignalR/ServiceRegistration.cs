using Microsoft.Extensions.DependencyInjection;
using StudentPortakAPI.SignalR.HubServices;
using StudentPortalAPI.Application.Abstractions.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortakAPI.SignalR
{
    public static class ServiceRegistration
    {
        public static void AddSignalRServices(this IServiceCollection collection)
        {
            collection.AddTransient<IStudentHubService, StudentHubService>();
            collection.AddSignalR();
        }
    }
}
