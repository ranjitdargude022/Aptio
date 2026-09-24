using Aptio.Application.Services;
using Aptio.Domain.Entities;
using MediatR;

namespace Aptio.Application.MediatR.Queries
{
   public record class GetUsersQuery() : IRequest<IEnumerable<User>>;

    public class GetUserHandler(IUserService service) : IRequestHandler<GetUsersQuery, IEnumerable<User>>
    {
        public async Task<IEnumerable<User>> Handle (GetUsersQuery request, CancellationToken cancellationToken)
        {
            return await service.GetUsers();
        }
    }
    
}
