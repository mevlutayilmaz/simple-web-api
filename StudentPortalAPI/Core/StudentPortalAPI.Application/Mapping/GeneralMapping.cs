using AutoMapper;
using StudentPortalAPI.Application.Features.Commands.AppUsers.CreateUser;
using StudentPortalAPI.Domain.Entities.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Mapping
{
    public class GeneralMapping : Profile
    {
        public GeneralMapping() 
        {
            CreateMap<AppUser, CreateUserCommandRequest>()
                .ReverseMap();
        }
    }
}
