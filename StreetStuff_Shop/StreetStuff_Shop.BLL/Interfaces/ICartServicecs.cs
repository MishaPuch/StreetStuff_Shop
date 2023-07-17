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
        public void AddToCart(int UserId, int ProductId);
        public int GenerateUniqueCartId();
        public void RemoveFromCart(Cart cart);
        public Cart? GetCartById(int CartId);
        public Cart? GetCartById(int ProductId, int UserId);
        public void AddCart(Cart cart);
        public List<Cart> GetCarts();
        public Cart GetCart(int id);

    }
}
