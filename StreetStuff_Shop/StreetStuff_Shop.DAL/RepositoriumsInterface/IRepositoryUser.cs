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
        public User GetUser(string email, string password);
        public User GetUserById(int id);
        public void CreateUser(User user);
        public void ChangeUser(User user);
        public int GetUserCount();

    }
}
