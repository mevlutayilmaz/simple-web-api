using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using StudentPortalAPI.Application.Features.Commands.Students.CreateStudent;
using StudentPortalAPI.Application.Features.Commands.Students.RemoveStudent;
using StudentPortalAPI.Application.Features.Commands.Students.UpdateStudent;
using StudentPortalAPI.Application.Features.Queires.Students.GetAllStudent;
using StudentPortalAPI.Application.Features.Queires.Students.GetStudentById;
using StudentPortalAPI.Application.Repositories;
using StudentPortalAPI.Application.ViewModels.Products;
using StudentPortalAPI.Domain.Entities;
using System.Net;

namespace StudentPortalAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(AuthenticationSchemes = "Admin")]

    public class StudentsController : ControllerBase
    {
        readonly private IReadRepository<Student> _studentReadRepository;
        readonly private IWriteRepository<Student> _studentWriteRepository;

        readonly IMediator _mediator;

        public StudentsController(IReadRepository<Student> studentReadRepository, IWriteRepository<Student> studentWriteRepository, IMediator mediator)
        {
            _studentReadRepository = studentReadRepository;
            _studentWriteRepository = studentWriteRepository;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Get([FromQuery] GetAllStudentQueryRequest getAllStudentQueryRequest)
        {
            GetAllStudentQueryResponse response = await _mediator.Send(getAllStudentQueryRequest);
            return Ok(response);
        }

        [HttpGet("{Id}")]
        public async Task<IActionResult> Get([FromRoute] GetStudentByIdQueryRequest getStudentByIdQueryRequest)
        {
            GetStudentByIdQueryResponse response = await _mediator.Send(getStudentByIdQueryRequest);
            return Ok(response);
        }

        [HttpPost]
        public async Task<IActionResult> Post(CreateStudentCommandRequest createStudentCommandRequest)
        {
            CreateStudentCommandResponse response = await _mediator.Send(createStudentCommandRequest);
            return Ok();
        }

        [HttpPut]
        public async Task<IActionResult> Put(UpdateStudentCommandRequest updateStudentCommandRequest)
        {
            UpdateStudentCommandResponse response = await _mediator.Send(updateStudentCommandRequest);
            return Ok();
        }

        [HttpDelete("{Id}")]
        public async Task<IActionResult> Delete([FromRoute]RemoveStudentCommandRequest removeStudentCommandRequest)
        {
            RemoveStudentCommandResponse response = await _mediator.Send(removeStudentCommandRequest);
            return Ok();
        }
    }
}
