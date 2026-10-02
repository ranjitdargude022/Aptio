using Aptio.Application.Authentication;
using Aptio.Application.Services;
using Aptio.Domain.Entities;
using AutoMapper.Configuration.Annotations;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aptio.Application.MediatR.Command
{
    public record class EditUserCommand(User? User) : IRequest< User>;

    public class EditUserHandler(IUserService service, ILogger<EditUserHandler> logger):IRequestHandler<EditUserCommand,User>
    {
        public async Task<User?> Handle (EditUserCommand request, CancellationToken cancellationToken)
        {
            logger.LogInformation("Processing Edit User command.");

            var result = await service.Edit(request.User);
            if (result == null)
            {
                logger.LogWarning("EditUser command failed because the user was not found.");

                return null;
            }

            logger.LogInformation("Edit User command processed successfully for UserId {UserId}.", result.Id);

            return result;
        }
    }
}
