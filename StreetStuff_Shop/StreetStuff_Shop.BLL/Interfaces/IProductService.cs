using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.BLL.Interfaces
{
    public interface IProductService
    {        
        public Task AddQuantity(int id);
        public Task MinusQuantity(int id);
        public Task ChangeQuantity(int id, int quantity);
        public Task<List<Product>> GetProducts();








    }
}
