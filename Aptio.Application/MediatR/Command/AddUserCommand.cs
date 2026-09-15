using Aptio.Application.Authentication;
using Aptio.Application.Services;
using MediatR;

namespace Aptio.Application.MediatR.Command
{
    public record AddUserCommand(UserRequest User) : IRequest<UserResponse>;


    public class AddUserHandler(IUserService service):IRequestHandler<AddUserCommand,UserResponse>
    {
        public async Task<UserResponse>Handle(AddUserCommand request,CancellationToken cancellationToken)
        {
            return  await service.AddUserAsync(request.User);
        }
    }
}
