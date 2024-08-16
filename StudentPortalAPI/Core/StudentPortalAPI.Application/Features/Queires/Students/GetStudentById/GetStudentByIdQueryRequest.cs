using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Features.Queires.Students.GetStudentById
{
    public class GetStudentByIdQueryRequest : IRequest<GetStudentByIdQueryResponse>
    {
        public string Id { get; set; }
    }
}
