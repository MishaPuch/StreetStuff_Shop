using StreetStuff_Shop.Models;

namespace StreetStuff_Shop.ViewModels
{
    public class ProfileViewModel
    {
        public IEnumerable<Product>? products { get; set; }
        public IEnumerable<Liked>? liked { get; set; } 
    }
}
