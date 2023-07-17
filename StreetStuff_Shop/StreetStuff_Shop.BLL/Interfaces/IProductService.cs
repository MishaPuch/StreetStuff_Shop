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
        public void AddQuantity(int id);
        public void MinusQuantity(int id);
        public void ChangeQuantity(int id, int quantity);
        public List<Product> GetProducts();








    }
}
