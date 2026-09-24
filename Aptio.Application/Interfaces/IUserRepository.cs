using Aptio.Application.Services;
using Aptio.Domain.Entities;

namespace Aptio.Application.Interfaces
{
    public interface IUserRepository
    {
        Task<IEnumerable<User>> GetUsers();

        Task<User?> GetUsersById(long id);

        Task<User> AddUserAsync(User user);

        Task<User?> Edit(User user);
        //Task<User?> UpdateUser(User User);

        //Task<bool?> DeleteUser(long Id);
    }
}
