/*using Microsoft.AspNetCore.Http;
using Newtonsoft.Json;
using StreetStuff_Shop.Interfaces;
using StreetStuff_Shop.Models;
using System.Text;

namespace StreetStuff_Shop.DI
{
    public class SessionService : ISessionService
    {
        IHttpContextAccessor httpContextAccessor;
        public SessionService(IHttpContextAccessor httpContextAccessor)
        {
            this.httpContextAccessor = httpContextAccessor;

        }

        public void SetString(string key, string value)
        {
            var session = httpContextAccessor.HttpContext.Session;

            session.Set(key, Encoding.UTF8.GetBytes(value));
        }
        public User GetUserFromSession()
        {
            var session = httpContextAccessor.HttpContext.Session;
            var currentUser = session.GetString("CurrentUser");

            if (!string.IsNullOrEmpty(currentUser))
            {
                return JsonConvert.DeserializeObject<User>(currentUser);
            }
            return null;
        }
        public void RegistrUserInSession(User user)
        {
            var HttpContext = httpContextAccessor.HttpContext;
            HttpContext.Session.SetString("CurrentUser", JsonConvert.SerializeObject(user));
        }
        public void LogoutUser()
        {
            var HttpContext = httpContextAccessor.HttpContext;
            HttpContext.Session.Clear();

        }      
    }
}
*/