using MediatR;
using StudentPortalAPI.Application.Repositories;
using StudentPortalAPI.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentPortalAPI.Application.Features.Commands.Students.RemoveStudent
{
    public class RemoveStudentCommandHandler : IRequestHandler<RemoveStudentCommandRequest, RemoveStudentCommandResponse>
    {
        readonly IWriteRepository<Student> _studentWriteRepository;

        public RemoveStudentCommandHandler(IWriteRepository<Student> writeRepository)
        {
            _studentWriteRepository = writeRepository;
        }
        public async Task<RemoveStudentCommandResponse> Handle(RemoveStudentCommandRequest request, CancellationToken cancellationToken)
        {
            await _studentWriteRepository.RemoveAsync(request.Id);
            await _studentWriteRepository.SaveAsync();
            return new();
        }
    }
}
