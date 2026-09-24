using Aptio.Application.Authentication;
using Aptio.Application.MediatR.Command;
using Aptio.Application.MediatR.Queries;
using Aptio.Domain.Entities;
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

        [Route("RegisterUser")]
        [HttpPost]
        public async Task<IActionResult> AddUser(UserRequest request)
        {
            var result = await _mediator.Send(new AddUserCommand(request));
            return Ok(result);
        }

        [Route("GetUsers")]
        [HttpGet]
        public async Task<IActionResult> GetUsers()
        {
            var result = await _mediator.Send(new GetUsersQuery());
            return Ok(result); 
        }

        [Route("GetUsersById")]
        [HttpGet]
        public async Task<IActionResult>GetUsersById(long id)
        {
            var result = await _mediator.Send(new GetUsersByIdQuery(id));
            return Ok(result);
        }

        [Route("UpdateUser")]
        [HttpPost]
        public async Task<IActionResult>Edit(User user)
        {
            var result = await _mediator.Send(new EditUserCommand(user));
            if (result == null)
                return NotFound();

            return Ok(result);
            
        }
    }
}
