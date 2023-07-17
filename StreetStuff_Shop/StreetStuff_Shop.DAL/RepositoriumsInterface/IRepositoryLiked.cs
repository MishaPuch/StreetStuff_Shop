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
        public Liked GetLikedById(int ProductId, int UserId);     
        public IEnumerable<Liked>? GetAllLikedProducts();
        public void AddLiked(Liked liked);
        public void SaveChanges();
        public void RemoveProductFromLiked(Liked liked);
        public int GetUniqueLikedId();




    }
}
