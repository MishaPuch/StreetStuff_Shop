using StreetStuff_Shop.Interfaces;

namespace StreetStuff_Shop.DI
{
    public class DbContext : IDbContext
    {
        

        

        public StreetStuffContext AppDbContext()
        {
            StreetStuffContext db = new StreetStuffContext();
            
            return db;
        }

      
    }
}
