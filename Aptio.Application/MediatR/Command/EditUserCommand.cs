using Aptio.Application.Authentication;
using Aptio.Application.Services;
using Aptio.Domain.Entities;
using MediatR;

namespace Aptio.Application.MediatR.Command
{
    public record class EditUserCommand(User? User) : IRequest< User>;

    public class EditUserHandler(IUserService service):IRequestHandler<EditUserCommand,User>
    {
        public async Task<User?>Handle (EditUserCommand request, CancellationToken cancellationToken)
        {
            return await service.Edit(request.User);
        }
    }
}
