using StreetStuff_Shop.Interfaces;
using StreetStuff_Shop.Models;
using Newtonsoft.Json;
using StreetStuff_Shop.DAL.RepositoriumsInterface;

namespace StreetStuff_Shop.DI
{
    public class UserService : IUserService
    {

        private IRepositoryLiked repositoryLiked;
        private IRepositoryCarts repositoryCarts;
        private IRepositoryProducts repositoryProducts;
        private IRepositoryUsers repositoryUsers;

        public UserService(IRepositoryCarts repositoryCarts,IRepositoryLiked repositoryLiked, IRepositoryProducts repositoryProducts, IRepositoryUsers repositoryUsers) 
        {
            this.repositoryCarts = repositoryCarts;
            this.repositoryProducts = repositoryProducts;
            this.repositoryUsers = repositoryUsers;
            this.repositoryLiked = repositoryLiked;
        }
               
        public void ChangeUser(User user)
        {
            repositoryUsers.ChangeUser(user);
        }

        public void CreateUser(User user)
        {
            repositoryUsers.CreateUser(user);
        }

        public User GetUser(string email, string password)
        {
            return repositoryUsers.GetUser(email, password);
        }

        public User GetUserById(int id)
        {
            return repositoryUsers.GetUserById(id);
        }

        public int GetUserCount()
        {
            return repositoryUsers.GetUserCount();
        }
    }
}
