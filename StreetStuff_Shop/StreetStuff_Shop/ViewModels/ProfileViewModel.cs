using StreetStuff_Shop.Models;

namespace StreetStuff_Shop.ViewModels
{
    public class ProfileViewModel
    {
        public IEnumerable<Product>? Products { get; set; }
        public IEnumerable<Liked>? Liked { get; set; } 
    }
}
