using Aptio.Application.Services;
using Aptio.Domain.Entities;
using MediatR;
using Microsoft.Extensions.Logging;

namespace Aptio.Application.MediatR.Queries
{
   public record class GetUsersQuery() : IRequest<IEnumerable<User>>;

    public class GetUserHandler(IUserService service, ILogger<GetUsersQuery> logger) : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        public async Task<IEnumerable<User>> Handle (GetUsersQuery request, CancellationToken cancellationToken)
        {
            logger.LogInformation( "Processing GetUsers query.");

            var result = await service.GetUsers();

            logger.LogInformation( "GetUsers query completed successfully. Retrieved {UserCount} users.", result.Count());

            return result;
        }
    }
    
}
