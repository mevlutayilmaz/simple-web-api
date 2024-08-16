using Microsoft.AspNetCore.Builder;
using StudentPortakAPI.SignalR.Hubs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortakAPI.SignalR
{
    public static class HubRegistration
    {
        public static void MapHubs(this WebApplication application) 
        {
            application.MapHub<StudentHub>("students/hub");
        }
    }
}
