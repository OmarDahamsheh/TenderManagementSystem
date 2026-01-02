using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;
using Infrastructure;
using Microsoft.EntityFrameworkCore;

namespace Application.Repository.UserRepo
{
    public class UserRepository : IUserRepository
    {
        private readonly Context _context;
        public UserRepository(Context context)
        {
            _context= context;
        }
        
        public async Task AddUser(User user)
        {
            await _context.Users.AddAsync(user);
        }

        public async Task<User?> GetUserByEmail(string email)
        {
            return await _context.Users.FindAsync(email); //*****
        }

        public async Task<User?> GetUserById(int id)
        {
            return await _context.Users.FindAsync(id);
        }

        public void UpdateUser(User user)
        {
             _context.Users.Update(user);

        }
    }
}
