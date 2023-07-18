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
    public class RepositoryProducts : IRepositoryProducts
    {
        StreetStuffContext db;
        public RepositoryProducts(StreetStuffContext db)
        {
            this.db = db;
        }
        public async Task<List<Product>> GetProducts()
        {
            return await db.Products.ToListAsync();
        }
        
    }
}
