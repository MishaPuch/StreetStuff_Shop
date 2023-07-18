using Microsoft.EntityFrameworkCore.Metadata;
using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.DAL.RepositoriumsInterface
{
    public interface IRepositoryLiked
    {
        public Task<Liked> GetLikedById(int ProductId, int UserId);     
        public Task<IEnumerable<Liked>>? GetAllLikedProducts();
        public Task AddLiked(Liked liked);
        public Task SaveChanges();
        public Task RemoveProductFromLiked(Liked liked);
        public Task<int> GetUniqueLikedId();




    }
}
