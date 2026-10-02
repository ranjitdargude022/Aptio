using Aptio.Application.Services;
using Aptio.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aptio.Application.MediatR.Queries
{
    public record class GetUsersByIdQuery(long id) : IRequest<User>;

    public class GetUsersByIdHandler(IUserService service , ILogger<GetUserHandler> logger ) : IRequestHandler <GetUsersByIdQuery, User?>
    {
        public async Task<User?> Handle (GetUsersByIdQuery request,CancellationToken cancellationToken)
        {
            logger.LogInformation( "Processing GetUsersById query for UserId {UserId}.", request.id);
            var result = await service.GetUsersById(request.id);
            if (result == null)
            {
                logger.LogWarning("User with Id {UserId} was not found.", request.id);

                return null;
            }

            logger.LogInformation("GetUsersById query completed successfully for UserId {UserId}.",  request.id);
            return result;
        }
    }
   
}
