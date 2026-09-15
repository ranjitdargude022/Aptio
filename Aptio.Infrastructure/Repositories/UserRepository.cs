using Aptio.Application.Interfaces;
using Aptio.Domain.Entities;
using Aptio.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aptio.Infrastructure.Repositories
{
    public class UserRepository :IUserRepository
    {
        private readonly AptioDbContext _aptioDbContext;
        public UserRepository(AptioDbContext aptioDbContext)
        {
            _aptioDbContext = aptioDbContext;
        }

        //public async Task<IEnumerable<User>> GetUsers()
        //{
        //    var result = await _aptioDbContext.Users.ToListAsync();
        //    return result;
        //}

        public async Task<User>AddUserAsync(User user)
        {
            await _aptioDbContext.Users.AddAsync(user);
            await _aptioDbContext.SaveChangesAsync();
            return user;
        }
    }
}
