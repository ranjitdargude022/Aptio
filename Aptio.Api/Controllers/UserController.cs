using Aptio.Application.Authentication;
using Aptio.Application.MediatR.Command;
using MediatR;
using Microsoft.AspNetCore.Mvc;

namespace Aptio.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IMediator _mediator;
        public UserController(IMediator mediator)
        {
            _mediator = mediator;   

        }

        [Route("Register")]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserRequest request)
        {
            var result = await _mediator.Send(new AddUserCommand(request));
            return Ok(result);
        }
    }
}
