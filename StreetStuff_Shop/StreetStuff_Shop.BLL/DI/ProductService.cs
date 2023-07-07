
using Microsoft.EntityFrameworkCore.Metadata;
using StreetStuff_Shop.BLL.Interfaces;
using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.BLL.DI
{
    public class ProductService : IProductService
    {
        StreetStuffContext db;
        public ProductService(StreetStuffContext db)
        {
            this.db = db;
        }
        public void AddProductToLiked(int ProductId, int UserId)
        {
            Liked liked = new Liked();
            bool isIdUnique = false;

            do
            {
                liked.Id = GetUniqueLikedId(db);
                if (liked.Id > 0)
                    isIdUnique = !db.Liked.Any(l => l.Id == liked.Id);
            }
            while (!isIdUnique);

            liked.ProductId = ProductId;
            liked.UserId = UserId;

            db.Liked.Add(liked);
            db.SaveChanges();
        }

       

        public void AddToBasket(int UserId, int ProductId)
        {
            Cart cart = new Cart();
            bool isIdUnique = false;

            do
            {
                cart.Id = GenerateUniqueCartId();
                if (cart.Id > 0)
                    isIdUnique = !db.Carts.Any(c => c.Id == cart.Id);
            }
            while (!isIdUnique);

            cart.ProductId = ProductId;
            cart.UserId = UserId;
            cart.Quantity = 1;

            db.Carts.Add(cart);
            db.SaveChanges();
        }        

        public int GenerateUniqueCartId()
        {
            int maxAttempts = 100;
            int attemptCount = 0;

            while (attemptCount < maxAttempts)
            {
                int newId = new Random().Next(1, int.MaxValue);
                if (!db.Carts.Any(c => c.Id == newId))
                    return newId;

                attemptCount++;
            }


            return 0;
        }

        public IEnumerable<Product>? GetAllProducts()
        {
            return db.Products.ToList<Product>();
        }

        public IEnumerable<Liked>? GetAllLikedProducts()
        {
            return db.Liked.ToList<Liked>();
        }

        public int GetUniqueLikedId(StreetStuffContext db)
        {
            Random random = new Random();
            int maxAttempts = 100;
            int attemptCount = 0;

            while (attemptCount < maxAttempts)
            {
                int newId = random.Next(1, int.MaxValue);
                if (!db.Liked.Any(l => l.Id == newId))
                    return newId;

                attemptCount++;
            }

            return 0;
        }      

        public void RemoveFromBasket(Cart cart)
        {
            db.Carts.Remove(cart);
            db.SaveChanges();
        }

        public void RemoveProductFromLiked(Liked liked)
        {
            db.Liked.Remove(liked);
            db.SaveChanges();
        }

        public Liked GetLikedById(int ProductId ,int UserId)
        {
            return db.Liked.FirstOrDefault(p => p.ProductId == ProductId && p.UserId == UserId);
        }
                
        public Cart GetCartById(int id)
        {
            return db.Carts.FirstOrDefault(cart => cart.Id == id);
        }
    }
}
