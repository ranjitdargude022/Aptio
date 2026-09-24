using Aptio.Application.Interfaces;
using Aptio.Domain.Entities;
using Aptio.Infrastructure.DbContexts;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
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

       

        public async Task<IEnumerable<User>> GetUsers()
        {
            var result = await _aptioDbContext.Users.ToListAsync();
            return result;
        }

        public async Task<User?>GetUsersById(long id)
        {
            var result = await _aptioDbContext.Users.FirstOrDefaultAsync(x=>x.Id==id);
            return result;
        }

        public async Task<User?>Edit(User User)
        {
            var user = await _aptioDbContext.Users.FirstOrDefaultAsync(x => x.Id ==User.Id);
            if (user == null)
            {
                return null;
            }
            user.FirstName=User.FirstName;
            user.LastName=User.LastName;
            //user.Address=User.Address;
            //user.Phone=User.Phone;
            //user.Email=User.Email;
            await _aptioDbContext.SaveChangesAsync();
            return user;
            
        }
        public async Task<User>AddUserAsync(User user)
        {
            await _aptioDbContext.Users.AddAsync(user);
            await _aptioDbContext.SaveChangesAsync();
            return user;
        }
    }
}
