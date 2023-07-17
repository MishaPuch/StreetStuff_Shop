using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.BLL.Interfaces
{
    public interface ILikedService
    {
        public void RemoveProductFromLiked(Liked liked);
        public void AddProductToLiked(int ProductId, int UserId);
        public Liked GetLikedById(int ProductId, int UserId);
        public IEnumerable<Liked>? GetAllLikedProducts();
        public void AddLiked(Liked liked);
        public void SaveChanges();
    }
}
