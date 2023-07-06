using StreetStuff_Shop.Models;

namespace StreetStuff_Shop.Interfaces
{
    public interface IUserService
    {
        public void CreateUser(User user);
        public User FoundUser(string email , string password);
       

    }
}
