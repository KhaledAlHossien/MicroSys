using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using test_For_Microtik.Application.Users.Command.Create;
using test_For_Microtik.Application.Users.Query.GetAll;

namespace test_For_Microtik.API
{
    [ApiController]
    [Route("api/users")]
    public class UsersController : ControllerBase
    {
        private readonly IMediator _mediator;

        public UsersController(IMediator mediator)
        {
            _mediator = mediator;
        }

        [HttpPost]
        public async Task<IActionResult> Create(CreateUserCommand command)
        {
            var result = await _mediator.Send(command);

            if (!result.IsSuccess)
                return BadRequest(result.Error);

            return Ok(result.Value);
        }

        [HttpGet]
        //[Authorize]
        public async Task<IActionResult> Get()
        {
            var result = await _mediator.Send(new GetUsersQuery());

            return Ok(result.Value);
        }
    }
}
