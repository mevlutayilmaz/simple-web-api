using MediatR;
using StudentPortalAPI.Application.Repositories;
using StudentPortalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Features.Queires.Students.GetAllStudent
{

    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudentQueryRequest, GetAllStudentQueryResponse>
    {
        readonly IReadRepository<Student> _studentReadRepository;

        public GetAllStudentQueryHandler(IReadRepository<Student> readRepository)
        {
            _studentReadRepository = readRepository;
        }

        public async Task<GetAllStudentQueryResponse> Handle(GetAllStudentQueryRequest request, CancellationToken cancellationToken)
        {
            GetAllStudentQueryResponse response = new();
            response.Students = _studentReadRepository.GetAll();
            //IQueryable<Student> students = _studentReadRepository.GetAll();
            return response;
        }
    }
}
