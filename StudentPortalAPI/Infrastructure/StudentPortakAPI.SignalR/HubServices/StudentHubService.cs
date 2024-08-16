using Microsoft.AspNetCore.SignalR;
using StudentPortakAPI.SignalR.Hubs;
using StudentPortalAPI.Application.Abstractions.Hubs;

namespace StudentPortakAPI.SignalR.HubServices
{
    public class StudentHubService : IStudentHubService
    {
        readonly IHubContext<StudentHub> _hubContext;

        public StudentHubService(IHubContext<StudentHub> hubContext)
        {
            _hubContext = hubContext;
        }

        public async Task StudentAddedMessageAsync(string message) 
        {
            await _hubContext.Clients.All.SendAsync(ReceiveFunctionNames.StudentAddedMessage, message);
        }
    }
}
