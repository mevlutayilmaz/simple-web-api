using MediatR;
using StudentPortalAPI.Application.Repositories;
using StudentPortalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Features.Queires.Students.GetStudentById
{
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentByIdQueryRequest, GetStudentByIdQueryResponse>
    {
        readonly IReadRepository<Student> _studentReadRepository;

        public GetStudentByIdQueryHandler(IReadRepository<Student> readRepository)
        {
            _studentReadRepository = readRepository;
        }
        public async Task<GetStudentByIdQueryResponse> Handle(GetStudentByIdQueryRequest request, CancellationToken cancellationToken)
        {
            Student student = await _studentReadRepository.GetByIdAsync(request.Id);
            return new()
            {
                LastName = student.LastName,
                FirstName = student.FirstName,
                Address = student.Address,
                BirthDate = student.BirthDate,
                Email = student.Email,
                Gender = student.Gender,
                PhoneNumber = student.PhoneNumber,
                Courses = student.Courses,
            };
            
        }
    }
}
