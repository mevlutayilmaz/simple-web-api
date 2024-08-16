using MediatR;
using StudentPortalAPI.Application.Repositories;
using StudentPortalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Features.Commands.Students.UpdateStudent
{
    public class UpdateStudentCommandHandler : IRequestHandler<UpdateStudentCommandRequest, UpdateStudentCommandResponse>
    {
        readonly IReadRepository<Student> _studentReadRepository;
        readonly IWriteRepository<Student> _studentWriteRepository;

        public UpdateStudentCommandHandler(IReadRepository<Student> readRepository, IWriteRepository<Student> writeRepository)
        {
            _studentReadRepository = readRepository;
            _studentWriteRepository = writeRepository;
        }

        public async Task<UpdateStudentCommandResponse> Handle(UpdateStudentCommandRequest request, CancellationToken cancellationToken)
        {
            Student student = await _studentReadRepository.GetByIdAsync(request.Id, true);
            student.PhoneNumber = request.PhoneNumber;
            student.Address = request.Address;
            student.Email = request.Email;
            await _studentWriteRepository.SaveAsync();
            return new();
        }
    }
}
