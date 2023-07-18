using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StreetStuff_Shop.DAL.RepositoriumsInterface;
using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.DAL.RepositoriumsService
{
    public class RepositoryLiked : RepositoriumsInterface.IRepositoryLiked
    {
        StreetStuffContext db;
        public RepositoryLiked(StreetStuffContext db)
        {
            this.db = db;
        }
        public async Task<Liked> GetLikedById(int ProductId, int UserId)
        {
            return await db.Liked.FirstOrDefaultAsync(p => p.ProductId == ProductId && p.UserId == UserId);
        }       

        public async Task<IEnumerable<Liked>>? GetAllLikedProducts()
        {
            return await db.Liked.ToListAsync();
        }                

        public async Task<Liked?> GetLikedById(int likedId)
        {
            return await db.Liked.FindAsync(likedId);
        }

        public async Task AddLiked(Liked liked)
        {
            db.Liked.Add(liked);
            db.SaveChangesAsync();
        }             

        public async Task RemoveProductFromLiked(Liked liked)
        {

            db.Liked.Remove(liked);
            db.SaveChangesAsync();
        }
       
        public async Task SaveChanges()
        {
            await db.SaveChangesAsync();
        }
        public async Task<int> GetUniqueLikedId()
        {
            Random random = new Random();
            int maxAttempts = 100;
            int attemptCount = 0;

            while (attemptCount < maxAttempts)
            {
                int newId = random.Next(1, int.MaxValue);
                Liked  cart = await GetLikedById(newId);

                if (cart == null)
                   return newId;

                attemptCount++;
            }

            return 0;
        }

    }
}


