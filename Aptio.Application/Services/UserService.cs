using Aptio.Application.Authentication;
using Aptio.Application.Interfaces;
using Aptio.Domain.Entities;
using AutoMapper;

namespace Aptio.Application.Services
{
    public class UserService : IUserService
    {
        public readonly IMapper _mapper;
        public  readonly IUserRepository _userRepository;
        public UserService( IUserRepository userRepository, IMapper mappper)
        {
            _userRepository = userRepository;
            _mapper = mappper;
        }

        public async Task<IEnumerable<User>> GetUsers()
        {
            var getUsers = await _userRepository.GetUsers();
            return getUsers;

        }

        public async Task<User?>GetUsersById(long id)
        {
            var result = await _userRepository.GetUsersById(id);
            return result;
        }

        public async Task<UserResponse> AddUserAsync(UserRequest userRequest)
        {
            var user =  _mapper.Map<User>(userRequest);
            var CreateUser=await _userRepository.AddUserAsync(user);
            var response = _mapper.Map<UserResponse>(CreateUser);
            return response;
        }

        public async Task<User?>Edit(User User)
        {
            var result = await _userRepository.Edit(User);
            return result;
        }
       
    }
}
