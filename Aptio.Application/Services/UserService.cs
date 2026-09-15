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

        public async Task<UserResponse> AddUserAsync(UserRequest userRequest)
        {
            var user =  _mapper.Map<User>(userRequest);
            var CreateUser=await _userRepository.AddUserAsync(user);
            var response = _mapper.Map<UserResponse>(CreateUser);
            return response;
        }

       
    }
}
