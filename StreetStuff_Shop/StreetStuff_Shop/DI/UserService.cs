using StreetStuff_Shop.Interfaces;
using StreetStuff_Shop.Models;
using Newtonsoft.Json;

namespace StreetStuff_Shop.DI
{
    public class UserService : IUserService
    {
        IDbContext dbContext;
        IHttpContextAccessor httpContextAccessor;
        public UserService(IDbContext db,IHttpContextAccessor httpContextAccessor) 
        {
            this.dbContext = db;
            this.httpContextAccessor = httpContextAccessor;

        }


        public void CreateUser(User user)
        {
            var db = dbContext.AppDbContext();

            db.Users.Add(user);
            db.SaveChanges();
        }

        public User FoundUser(string email, string password)
        {
            var db = dbContext.AppDbContext();
            User? user=db.Users.FirstOrDefault(u=>u.Email==email &&u.Password==password);
            return user;
        }

        public void LogoutUser()
        {
            var HttpContext = httpContextAccessor.HttpContext;
            HttpContext.Session.Clear();

        }

        public void RegistrUserInSession(User user)
        {
            var HttpContext = httpContextAccessor.HttpContext;
            HttpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject(user));
        }
    }
}
