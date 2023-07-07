using StreetStuff_Shop.Models;

namespace StreetStuff_Shop.Interfaces
{
    public interface IUserService
    {
        public void CreateUser(User user);
        public User GetUser(string email , string password);
        public User GetUserById(int id);
        public bool ChangeUser(User user);




    }
}
