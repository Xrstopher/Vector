using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Vector.Application.Students.Commands.CreateStudent;
using Vector.Application.Students.Commands.DeleteStudent;
using Vector.Application.Students.Commands.UpdateStudent;
using Vector.Application.Students.Queries;

namespace Vector.WebUI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentsController : ApiControllerBase
    {
        [HttpGet]
        public async Task<IEnumerable<StudentDto>> Get()
        {
            return await Mediator.Send(new GetStudentsQuery());
        }

        [HttpPost]
        public async Task<ActionResult<int>> Create(CreateStudentCommand command)
        {
            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateStudentCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new DeleteStudentCommand { Id = id });

            return NoContent();
        }
    }
}
