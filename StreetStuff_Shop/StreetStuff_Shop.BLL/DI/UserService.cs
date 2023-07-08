using StreetStuff_Shop.Interfaces;
using StreetStuff_Shop.Models;
using Newtonsoft.Json;
using StreetStuff_Shop.DAL;

namespace StreetStuff_Shop.DI
{
    public class UserService : IUserService
    {

        StreetStuffContext db;
        IRepository repository;

        public UserService(StreetStuffContext db , IRepository repository) 
        {
            this.db = db;
            this.repository = repository;

        }
               
        public void ChangeUser(User user)
        {
            repository.ChangeUser(user);
        }

        public void CreateUser(User user)
        {
            repository.CreateUser(user);
        }
    }
}
