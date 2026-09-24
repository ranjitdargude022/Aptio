using Aptio.Application.Authentication;
using Aptio.Domain.Entities;

namespace Aptio.Application.Services
{
    public interface IUserService
    {
        Task<IEnumerable<User>> GetUsers();
        Task<User?> GetUsersById(long id);
        Task<UserResponse> AddUserAsync(UserRequest userRequest);
        Task<User?> Edit(User User);
        //Task<User?> Edit(long id);
    }
}
