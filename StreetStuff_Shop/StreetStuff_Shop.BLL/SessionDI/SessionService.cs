using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.Configuration;
using Newtonsoft.Json;
using StreetStuff_Shop.Interfaces;
using StreetStuff_Shop.Models;
using System.Text;


namespace StreetStuff_Shop.DI
{
    public class SessionService : ISessionService
    {
        IHttpContextAccessor httpContextAccessor;
        IConfiguration configuration;
        public SessionService(IHttpContextAccessor httpContextAccessor, IConfiguration configuration)
        {
            this.httpContextAccessor = httpContextAccessor;
            this.configuration = configuration;
        }
        public void SetString(string key, string value)
        {
            var session = httpContextAccessor.HttpContext.Session;

            session.Set(key, Encoding.UTF8.GetBytes(value));
        }
        public string? GetString(string key)
        {
            var session = httpContextAccessor.HttpContext.Session;

            var data = Get(key);
            if (data == null)
            {
                return null;
            }
            return Encoding.UTF8.GetString(data);
        }
        public byte[]? Get(string key)
        {
            var session = httpContextAccessor.HttpContext.Session;

            session.TryGetValue(key, out var value);
            return value;
        }

        public User GetUserFromSession()
        {
            var session = httpContextAccessor.HttpContext.Session;
            var currentUser = GetString("CurrentUser");
           

            if (!string.IsNullOrEmpty(currentUser))
            {
                return JsonConvert.DeserializeObject<User>(currentUser);
            }
            return null;
        }
        public void RegistrUserInSession(User user)
        {
            var HttpContext = httpContextAccessor.HttpContext;
            SetString("CurrentUser", JsonConvert.SerializeObject(user));
        }
        public void LogoutUser()
        {
            var HttpContext = httpContextAccessor.HttpContext;
            HttpContext.Session.Clear();
        }
    }
}
