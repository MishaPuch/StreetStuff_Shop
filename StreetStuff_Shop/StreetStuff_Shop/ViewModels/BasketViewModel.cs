using StreetStuff_Shop.Models;

namespace StreetStuff_Shop.ViewModels
{
    public class BasketViewModel
    {
        public IEnumerable<Product> ? Products { get; set; }
        public IEnumerable<Cart> ? Carts { get; set; }
    }
}
