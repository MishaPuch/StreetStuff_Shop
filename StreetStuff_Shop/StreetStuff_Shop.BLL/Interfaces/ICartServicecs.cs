using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.BLL.Interfaces
{
    public interface ICartServicecs
    {
        public Task AddToCart(int UserId, int ProductId);
        public Task<int> GenerateUniqueCartId();
        public Task RemoveFromCart(Cart cart);
        public Task<Cart>? GetCartById(int CartId);
        public Task<Cart>? GetCartById(int ProductId, int UserId);
        public Task AddCart(Cart cart);
        public Task<List<Cart>> GetCarts();
        public Task<Cart> GetCart(int id);


    }
}
