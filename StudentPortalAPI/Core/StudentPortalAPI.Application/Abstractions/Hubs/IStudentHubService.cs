using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Abstractions.Hubs
{
    public interface IStudentHubService
    {
        Task StudentAddedMessageAsync(string message);
    }
}
