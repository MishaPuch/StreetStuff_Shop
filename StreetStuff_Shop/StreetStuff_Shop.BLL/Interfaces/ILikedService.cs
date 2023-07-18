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
        public Task RemoveProductFromLiked(Liked liked);
        public Task AddProductToLiked(int ProductId, int UserId);
        public Task<Liked> GetLikedById(int ProductId, int UserId);
        public Task<IEnumerable<Liked>>? GetAllLikedProducts();
        public Task AddLiked(Liked liked);
        public Task SaveChanges();
    }
}
