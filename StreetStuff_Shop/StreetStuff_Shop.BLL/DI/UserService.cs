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
               
        public async Task ChangeUser(User user)
        {
            await repositoryUsers.ChangeUser(user);
        }

        public async Task CreateUser(User user)
        {
            await repositoryUsers.CreateUser(user);
        }

        public async Task<User> GetUser(string email, string password)
        {
            return await repositoryUsers.GetUser(email, password);
        }

        public async Task<User> GetUserById(int id)
        {
            return await repositoryUsers.GetUserById(id);
        }

        public async Task<int> GetUserCount()
        {
            return await repositoryUsers.GetUserCount();
        }
    }
}
