using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.DAL.RepositoriumsInterface
{
    public interface IRepositoryCarts
    {
        public Task<Cart>? GetCartById(int id);
        public Task<Cart> GetCartById(int ProductId, int UserId);
        public Task AddCart(Cart cart);
        public Task<List<Cart>> GetCarts();
        public Task<Cart> GetCart(int id);
        public Task RemoveFromCart(Cart cart);
        public Task<int> GetUniqueCartId(); 

    }
}
