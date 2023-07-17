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
        public Liked GetLikedById(int ProductId, int UserId)
        {
            return db.Liked.FirstOrDefault(p => p.ProductId == ProductId && p.UserId == UserId);
        }       

        public IEnumerable<Liked>? GetAllLikedProducts()
        {
            return db.Liked.ToList();
        }                

        public Liked? GetLikedById(int likedId)
        {
            return db.Liked.Find(likedId);
        }

        public void AddLiked(Liked liked)
        {
            db.Liked.Add(liked);
            db.SaveChanges();
        }             

        public void RemoveProductFromLiked(Liked liked)
        {

            db.Liked.Remove(liked);
            db.SaveChanges();
        }
       
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        public int GetUniqueLikedId()
        {
            Random random = new Random();
            int maxAttempts = 100;
            int attemptCount = 0;

            while (attemptCount < maxAttempts)
            {
                int newId = random.Next(1, int.MaxValue);
                Liked  cart = GetLikedById(newId);

                if (cart == null)
                    return newId;

                attemptCount++;
            }

            return 0;
        }

    }
}


