using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using StudentPortalAPI.Application.Repositories;
using StudentPortalAPI.Application.ViewModels.Courses;
using StudentPortalAPI.Domain.Entities;
using System.Net;

namespace StudentPortalAPI.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CoursesController : ControllerBase
    {
        private readonly IReadRepository<Course> _courseReadRepository;
        private readonly IWriteRepository<Course> _courseWriteRepository;

        public CoursesController (IReadRepository<Course> readRepository, IWriteRepository<Course> writeRepository)
        {
            _courseReadRepository = readRepository;
            _courseWriteRepository = writeRepository;
        }

        [HttpGet]
        public async Task<IActionResult> GetCourses()
        {
            return Ok(_courseReadRepository.GetAll());
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetCoursesById(string id)
        {
            return Ok(await _courseReadRepository.GetByIdAsync(id));
        }

        [HttpPost]
        public async Task<IActionResult> PostCourse(VM_Create_Course model)
        {
            await _courseWriteRepository.AddAsync(new()
            {
                CourseName = model.CourseName,
                Credits = model.Credits
            });
            await _courseWriteRepository.SaveAsync();
            return StatusCode((int)HttpStatusCode.Created);
        }

        [HttpPut]
        public async Task<IActionResult> PutCourse(VM_Update_Course model)
        {
            Course course = await _courseReadRepository.GetByIdAsync(model.Id, true);
            course.CourseName = model.CourseName;
            course.Credits = model.Credits;
            await _courseWriteRepository.SaveAsync();
            return Ok();
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCourse(string id)
        {
            await _courseWriteRepository.RemoveAsync(id);
            await _courseWriteRepository.SaveAsync();
            return Ok();
        }
    }
}
