using Aptio.Application.Authentication;
using Aptio.Application.Services;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aptio.Application.MediatR.Command
{
    public record AddUserCommand(UserRequest User) : IRequest<UserResponse>;


    public class AddUserHandler (IUserService service,ILogger <AddUserHandler> logger):IRequestHandler<AddUserCommand,UserResponse>
    {
        public async Task<UserResponse> Handle (AddUserCommand request,CancellationToken cancellationToken)
        {
            logger.LogInformation("Processing Add User command.");

            var result = await service.AddUserAsync(request.User);

            logger.LogInformation( "AddUser command processed successfully for UserId {UserId}.", result.Id);

            return result;
        }
    }
}
