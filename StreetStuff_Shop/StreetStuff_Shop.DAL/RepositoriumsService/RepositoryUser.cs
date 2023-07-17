using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.DAL.RepositoriumsInterface
{
    public class RepositoryUser:IRepositoryUsers
    {
        StreetStuffContext db;
        public RepositoryUser(StreetStuffContext db)
        {
            this.db = db;
        }
        public User GetUser(string email, string password)
        {
            return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
        public User GetUserById(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }

        public void CreateUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();

        }

        public void ChangeUser(User user)
        {
            User ChangedUser = db.Users.FirstOrDefault(u => u.Id == user.Id);
            ChangedUser = user;
            db.SaveChanges();
        }
        public int GetUserCount()
        {
            return db.Users.Count();
        }

    }
}
