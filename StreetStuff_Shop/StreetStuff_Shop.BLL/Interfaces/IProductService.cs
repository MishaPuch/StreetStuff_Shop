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
        public IEnumerable<Product>? GetAllProducts();

        public IEnumerable<Liked>? GetAllLikedProducts();
        public void RemoveProductFromLiked(Liked liked);
        public void AddProductToLiked(int ProductId, int UserId);
        public void AddToBasket(int UserId, int ProductId);
        public int GenerateUniqueCartId();
        public void RemoveFromBasket(Cart cart);
        public int GetUniqueLikedId(StreetStuffContext db);
        public Liked GetLikedById(int ProductId, int UserId);
        public Cart GetCartById(int ProductId);







    }
}
