using ManageStudents.Commands;
using ManageStudents.Queries;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace ManageStudents.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class StudentsController : ControllerBase
    {
        private readonly IMediator _mediator;

        public StudentsController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> GetStudents()
        {
            var students = await _mediator.Send(new GetStudentsQuery());
            return Ok(students);
        }

        [HttpGet("{id}")]
        public async Task<IActionResult> GetStudent(int id)
        {
            var student = await _mediator.Send(new GetStudentByIdQuery { Id = id});
            return Ok(student);
        }


        [HttpPost]
        public async Task<IActionResult> CreateStudent([FromBody] CreateStudentCommand command)
        {
            var student = await _mediator.Send(command);
            return Ok(student);
        }

        [HttpPut]
        public async Task<IActionResult> UpdateStudent(int id,[FromBody] UpdateStudentCommand command)
        {
            command.Id = id;
            var student = await _mediator.Send(command);
            return Ok(student);
        }

        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteStudent(int id)
        {
            await _mediator.Send(new DeleteStudentCommand { Id = id });
            return Ok();
        }

    }
    
}