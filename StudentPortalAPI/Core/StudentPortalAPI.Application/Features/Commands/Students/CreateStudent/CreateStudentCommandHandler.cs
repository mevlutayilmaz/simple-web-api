using MediatR;
using StudentPortalAPI.Application.Repositories;
using StudentPortalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Features.Commands.Students.CreateStudent
{
    public class CreateStudentCommandHandler : IRequestHandler<CreateStudentCommandRequest, CreateStudentCommandResponse>
    {
        readonly IWriteRepository<Student> _studentWriteRepository;
        public CreateStudentCommandHandler(IWriteRepository<Student> writeRepository)
        {
            _studentWriteRepository = writeRepository;
        }
        public async Task<CreateStudentCommandResponse> Handle(CreateStudentCommandRequest request, CancellationToken cancellationToken)
        {
            await _studentWriteRepository.AddAsync(new()
            {
                FirstName = request.FirstName,
                LastName = request.LastName,
                BirthDate = request.BirthDate,
                Address = request.Address,
                Email = request.Email,
                Gender = request.Gender,
                PhoneNumber = request.PhoneNumber,
            });
            await _studentWriteRepository.SaveAsync();
            return new();
        }
    }
}
