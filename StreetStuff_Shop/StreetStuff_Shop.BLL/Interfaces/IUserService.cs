using StreetStuff_Shop.Models;

namespace StreetStuff_Shop.Interfaces
{
    public interface IUserService
    {
        public Task CreateUser(User user);        
        public Task ChangeUser(User user);
        public Task<User> GetUser(string email, string password);
        public Task<User> GetUserById(int id);        
        public Task<int> GetUserCount();

    }
}
