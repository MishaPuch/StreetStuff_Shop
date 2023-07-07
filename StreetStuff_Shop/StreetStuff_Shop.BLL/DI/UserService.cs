using StreetStuff_Shop.Interfaces;
using StreetStuff_Shop.Models;
using Newtonsoft.Json;


namespace StreetStuff_Shop.DI
{
    public class UserService : IUserService
    {

        StreetStuffContext db;
        public UserService(StreetStuffContext db) 
        {
            this.db = db;

        }

        public void CreateUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();
        }

        public User GetUser(string email, string password)
        {
            User? user=db.Users.FirstOrDefault(u=>u.Email==email &&u.Password==password);
            return user;
        }     
        public User GetUserById(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }
        public bool ChangeUser(User user)
        {
            User ChangedUser = db.Users.FirstOrDefault(u=>u.Id==user.Id);
            ChangedUser = user;
            db.SaveChanges();
            return true;
        }


    }
}
