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
        public Cart? GetCartById(int id);
        public Cart GetCartById(int ProductId, int UserId);
        public void AddCart(Cart cart);
        public List<Cart> GetCarts();
        public Cart GetCart(int id);
        public void RemoveFromCart(Cart cart);
        public int GetUniqueCartId();

    }
}
