using Microsoft.EntityFrameworkCore;
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
        public async Task<User> GetUser(string email, string password)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Email == email && u.Password == password);
        }
        public async Task<User> GetUserById(int id)
        {
            return await db.Users.FirstOrDefaultAsync(u => u.Id == id);
        }

        public async Task CreateUser(User user)
        {
            db.Users.Add(user);
            await db.SaveChangesAsync();

        }

        public async Task ChangeUser(User user)
        {
            User ChangedUser = db.Users.FirstOrDefault(u => u.Id == user.Id);
            ChangedUser = user;
            await db.SaveChangesAsync();
        }
        public async Task<int> GetUserCount()
        {
            return await db.Users.CountAsync();
        }

    }
}
