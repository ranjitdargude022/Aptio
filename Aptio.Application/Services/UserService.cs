using Aptio.Application.Authentication;
using Aptio.Application.Interfaces;
using Aptio.Domain.Entities;
using AutoMapper;
using Microsoft.Extensions.Logging;

namespace Aptio.Application.Services
{
    public class UserService : IUserService
    {
        public readonly IMapper _mapper;
        public  readonly IUserRepository _userRepository;
        public readonly ILogger<UserService> _logger;
        public UserService( IUserRepository userRepository, IMapper mappper, ILogger<UserService> logger)
        {
            _userRepository = userRepository;
            _mapper = mappper;
            _logger = logger;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            _logger.LogInformation("Fetching all user details");
            var getUsers = await _userRepository.GetUsers();
            _logger.LogInformation("Successfully fetched {UserCount} users.",getUsers.Count());
            return getUsers;

        }

        public async Task<User?>GetUsersById(long id)
        {
            _logger.LogInformation("Fetching user with Id {UserId}.", id);
            var result = await _userRepository.GetUsersById(id);
            _logger.LogWarning( "User with Id {UserId} was not found.",id);
            return result;
        }

        public async Task<UserResponse> AddUserAsync(UserRequest userRequest)
        {
            _logger.LogInformation("Creating a new user.");
            var user =  _mapper.Map<User>(userRequest);
            var CreateUser=await _userRepository.AddUserAsync(user);
            var response = _mapper.Map<UserResponse>(CreateUser);
            _logger.LogInformation("User created successfully with Id {UserId}.", CreateUser.Id);
            return response;
        }

        public async Task<User?>Edit(User User)
        {
            _logger.LogInformation("Updating user with Id {UserId}.",User.Id);
            var result = await _userRepository.Edit(User);
            if (result == null)
            {
                _logger.LogWarning("User with Id {UserId} could not be updated.",User.Id);
            }
            return result;
        }
       
    }
}
