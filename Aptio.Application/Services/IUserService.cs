using Aptio.Application.Authentication;

namespace Aptio.Application.Services
{
    public interface IUserService
    {
       // Task<IEnumerable<User>> GetUsersAsync();
        Task<UserResponse> AddUserAsync(UserRequest userRequest);
    }
}
