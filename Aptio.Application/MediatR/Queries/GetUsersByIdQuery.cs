using Aptio.Application.Services;
using Aptio.Domain.Entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace Aptio.Application.MediatR.Queries
{
    public record class GetUsersByIdQuery(long id) : IRequest<User>;

    public class GetUsersByIdHandler(IUserService service) : IRequestHandler <GetUsersByIdQuery, User?>
    {
        public async Task<User?> Handle(GetUsersByIdQuery request,CancellationToken cancellationToken)
        {
            return await service.GetUsersById(request.id);
        }
    }
   
}
