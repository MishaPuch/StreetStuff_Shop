using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.DAL.RepositoriumsInterface
{
    public interface IRepositoryUsers
    {
        public Task<User> GetUser(string email, string password);
        public Task<User> GetUserById(int id);
        public Task CreateUser(User user);
        public Task ChangeUser(User user);
        public Task<int> GetUserCount();

    }
}
