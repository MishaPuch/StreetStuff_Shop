using StreetStuff_Shop.DAL.RepositoriumsInterface;
using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.DAL.RepositoriumsService
{
    public class RepositoryCarts : IRepositoryCarts
    {
        StreetStuffContext db;
        public RepositoryCarts(StreetStuffContext db)
        {
            this.db = db;
        }
        public Cart? GetCartById(int ProductId, int UserId)
        {
            return db.Carts.FirstOrDefault(p => p.ProductId == ProductId && p.UserId == UserId);
        }

        public List<Cart> GetCarts()
        {
            return db.Carts.ToList();
        }

        public Cart GetCartById(int id)
        {
            return db.Carts.Find(id);
        }
        public void AddCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }
        public void RemoveFromCart(Cart cart)
        {
            db.Carts.Remove(cart);
            db.SaveChanges();
        }
        public Cart GetCart(int newId)
        {
            return db.Carts.FirstOrDefault(c => c.Id == newId);
        }
        public int GetUniqueCartId()
        {
            Random random = new Random();
            int maxAttempts = 100;
            int attemptCount = 0;

            while (attemptCount < maxAttempts)
            {
                int newId = random.Next(1, int.MaxValue);
                Cart cart = GetCart(newId);

                if (cart == null)
                    return newId;

                attemptCount++;
            }

            return 0;
        }
    }
}
