using Microsoft.EntityFrameworkCore;
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
        public async Task<Cart>? GetCartById(int ProductId, int UserId)
        {
            return await db.Carts.FirstOrDefaultAsync(p => p.ProductId == ProductId && p.UserId == UserId);
        }

        public async Task<List<Cart>> GetCarts()
        {
            return await db.Carts.ToListAsync();
        }

        public async Task<Cart> GetCartById(int id)
        {
            return await db.Carts.FindAsync(id); 
        }
        public async Task AddCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChangesAsync();
        }
        public async Task RemoveFromCart(Cart cart)
        {
            db.Carts.Remove(cart);
            await db.SaveChangesAsync();
        }
        public async Task<Cart> GetCart(int newId)
        {
            return await db.Carts.FirstOrDefaultAsync(c => c.Id == newId);
        }
        public async Task<int> GetUniqueCartId()
        {
            Random random = new Random();
            int maxAttempts = 100;
            int attemptCount = 0;

            while (attemptCount < maxAttempts)
            {
                int newId = random.Next(1, int.MaxValue);
                var cart =await GetCart(newId);

                if (cart == null)
                    return newId;

                attemptCount++;
            }

            return 0;
        }
    }
}
