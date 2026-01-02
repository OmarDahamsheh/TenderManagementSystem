using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Domain.Models;

namespace Application.Repository.UserRepo
{
    public interface IUserRepository
    {
        public Task<User?> GetUserByEmail(string email);
        public Task<User?> GetUserById(int id);
        public Task AddUser(User user);
        public void UpdateUser(User user);
    }
}
