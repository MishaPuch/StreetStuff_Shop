using Microsoft.EntityFrameworkCore.Metadata;
using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.DAL
{
    public interface IRepository
    {
        public Liked GetLikedById(int ProductId, int UserId);
        public Cart? GetCartById(int id);
        public Cart GetCartById(int ProductId, int UserId);
        public IEnumerable<Liked>? GetAllLikedProducts();
        public User GetUser(string email, string password);
        public User GetUserById(int id);
        public List<Product> GetProducts();
        public List<Cart> GetCarts();
        public void CreateUser(User user);
        public void ChangeUser(User user);
        public void AddLiked(Liked liked);
        public void AddCart(Cart cart);
        public void RemoveProductFromLiked(Liked liked);
        public void RemoveFromBasket(Cart cart);
        public void SaveChanges();



    }
}
