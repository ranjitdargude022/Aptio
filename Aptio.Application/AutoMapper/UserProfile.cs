using Aptio.Application.Authentication;
using Aptio.Domain.Entities;
using AutoMapper;

namespace Aptio.Application.AutoMapper
{
    public class UserProfile :Profile
    {
        public UserProfile()
        {
            CreateMap<UserRequest, User>();
            CreateMap<User, UserResponse>();
        }
    }
}
