using StreetStuff_Shop.Models;

namespace StreetStuff_Shop.ViewModels
{
    public class BasketViewModel
    {
        public IEnumerable<Product> ? products { get; set; }
        public IEnumerable<Cart> ? carts { get; set; }
    }
}
