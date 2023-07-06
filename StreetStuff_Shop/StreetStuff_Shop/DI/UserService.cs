﻿using StreetStuff_Shop.Interfaces;
using StreetStuff_Shop.Models;
using Newtonsoft.Json;
using Microsoft.AspNetCore.Http;


namespace StreetStuff_Shop.DI
{
    public class UserService : IUserService
    {
        StreetStuffContext dbContext;
        IHttpContextAccessor httpContextAccessor;
        public UserService(StreetStuffContext db,IHttpContextAccessor httpContextAccessor) 
        {
            this.dbContext = db;
            this.httpContextAccessor = httpContextAccessor;

        }


        public void CreateUser(User user)
        {
            var db = dbContext;

            db.Users.Add(user);
            db.SaveChanges();
        }

        public User FoundUser(string email, string password)
        {
            var db = dbContext;
            User? user=db.Users.FirstOrDefault(u=>u.Email==email &&u.Password==password);
            return user;
        }

        

       


    }
}
