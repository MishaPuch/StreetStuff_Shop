﻿using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;
using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.DAL
{
    public class Repository : IRepository
    {
        StreetStuffContext db;
        public Repository(StreetStuffContext db)
        {
            this.db = db;
        }
        public Liked GetLikedById(int ProductId, int UserId)
        {
            return db.Liked.FirstOrDefault(p => p.ProductId == ProductId && p.UserId == UserId);
        }

        public Cart? GetCartById(int ProductId, int UserId)
        {
            return db.Carts.FirstOrDefault(p => p.ProductId == ProductId && p.UserId == UserId);
        }

        public async Task<IEnumerable<Liked>>? GetAllLikedProducts()
        {
            return await Task.Run(()=> db.Liked.ToList());
        }
        public User GetUser(string email, string password)
        {
            return db.Users.FirstOrDefault(u => u.Email == email && u.Password == password);
        }
        public User GetUserById(int id)
        {
            return db.Users.FirstOrDefault(u => u.Id == id);
        }
        public async Task<List<Product>> GetProducts()
        {
            return await Task.Run(()=> db.Products.ToList());
        }

        public async Task<List<Cart>> GetCarts()
        {
            return await Task.Run(() => db.Carts.ToList());
        }

        public Cart GetCartById(int id)
        {
            return db.Carts.Find(id);
        }

        public void CreateUser(User user)
        {
            db.Users.Add(user);
            db.SaveChanges();

        }

        public void ChangeUser(User user)
        {
            User ChangedUser = db.Users.FirstOrDefault(u => u.Id == user.Id);
            ChangedUser = user;
            db.SaveChanges();
        }

        public bool GetLikedById(int likedId)
        {
            return db.Liked.Any(l => l.Id == likedId);
        }

        public void AddLiked(Liked liked)
        {
            db.Liked.Add(liked);
            db.SaveChanges();
        }

        public void AddCart(Cart cart)
        {
            db.Carts.Add(cart);
            db.SaveChanges();
        }

        public void RemoveProductFromLiked(Liked liked)
        {

            db.Liked.Remove(liked);
            db.SaveChanges();
        }
        public void RemoveFromBasket(Cart cart)
        {
            db.Carts.Remove(cart);
            db.SaveChanges();
        }
        public void SaveChanges()
        {
            db.SaveChanges();
        }
        public Cart GetCart(int newId)
        {
            return db.Carts.FirstOrDefault(c => c.Id == newId);
        }
        public int GetUserCount()
        {
            return db.Users.Count();
        }

    }
}


