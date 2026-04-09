using MediatR;
using Microsoft.AspNetCore.Mvc;
using test_For_Microtik.Application.Department.Command.Create;
using test_For_Microtik.Application.Department.Command.Delete;
using test_For_Microtik.Application.Department.Command.Update;
using test_For_Microtik.Application.Department.Query.GetAll;
using test_For_Microtik.Application.Department.Query.GetById;

namespace test_For_Microtik.API
{
    [ApiController]
    [Route("api/[controller]")]
    public class DepartmentController : ControllerBase
    {
        private readonly IMediator _mediator;

        public DepartmentController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost("create")]
        public async Task<IActionResult> Create([FromForm] CreateDepartmentCommand command)
        {
            var result = await _mediator.Send(command);
            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpPut("{id}/update")]
        public async Task<IActionResult> Update(int id, [FromForm] string name)
        {
            var command = new UpdateDepartmentCommand(id, name);

            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
            {
                return BadRequest(result.Error); 
            }

            return Ok(result.Value);
        }



        [HttpDelete("delete/{id}")]
        public async Task<IActionResult> Delete(int id)
        {
            var result = await _mediator.Send(new DeleteDepartmentCommand(id));

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(new { message = "Department deleted successfully" });
        }
        [HttpGet("getAll")]
        public async Task<IActionResult> GetAll()
        {
            var result = await _mediator.Send(new GetAllDepartmentsQuery());

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Value); 
        }

        [HttpGet("get/{id}")] 
        public async Task<IActionResult> GetById(int id)
        {
            var result = await _mediator.Send(new GetDepartmentByIdQuery(id));

            if (!result.IsSuccess)
                return NotFound(result.Error); 

            return Ok(result.Value); 
        }
    }
}
