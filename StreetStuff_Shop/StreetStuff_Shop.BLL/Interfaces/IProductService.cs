using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.BLL.Interfaces
{
    public interface IProductService
    {        
        public void RemoveProductFromLiked(Liked liked);
        public void AddProductToLiked(int ProductId, int UserId);
        public void AddToBasket(int UserId, int ProductId);
        public int GenerateUniqueCartId();
        public void RemoveFromBasket(Cart cart);
        public void AddQuantity(int id);
        public void MinusQuantity(int id);
        public void ChangeQuantity(int id, int quantity);








    }
}
