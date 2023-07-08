
using Microsoft.EntityFrameworkCore.Metadata;
using StreetStuff_Shop.BLL.Interfaces;
using StreetStuff_Shop.DAL;
using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.BLL.DI
{
    public class ProductService : IProductService
    {
        private IRepository repository;
        public ProductService(IRepository repository)
        {
            this.repository = repository;
        }
        public void AddProductToLiked(int ProductId, int UserId)
        {
            Liked liked = new Liked();
            bool isIdUnique = false;

            do
            {
                liked.Id = GetUniqueLikedId();
                if (liked.Id > 0)
                    isIdUnique = repository.GetLikedById(liked.Id, UserId) == null;
            }
            while (!isIdUnique);

            liked.ProductId = ProductId;
            liked.UserId = UserId;

            repository.AddLiked(liked);

            
        }

        public void AddQuantity(int id)
        {
            Cart? cart = repository.GetCartById(id);
            cart.Quantity++;
            repository.SaveChanges();


        }

        public void AddToBasket(int UserId, int ProductId)
        {
            
                Cart cart = new Cart();
                bool isIdUnique = false;

                do
                {
                    cart.Id = GenerateUniqueCartId();
                    if (cart.Id > 0)
                        isIdUnique = repository.GetCartById(cart.Id) == null;
                }
                while (!isIdUnique);

                cart.ProductId = ProductId;
                cart.UserId = UserId;
                cart.Quantity = 1;

                repository.AddCart(cart);
            
        }

        public void ChangeQuantity(int id, int quantity)
        {
            Cart? cart = repository.GetCartById(id);
            cart.Quantity = quantity;
        }

        public int GenerateUniqueCartId()
        {
            int maxAttempts = 100;
            int attemptCount = 0;

            while (attemptCount < maxAttempts)
            {
                int newId = new Random().Next(1, int.MaxValue);
                if (repository.GetCartById(newId) == null)
                    return newId;

                attemptCount++;
            }

            return 0;
        }




        public int GetUniqueLikedId()
        {
            Random random = new Random();
            int maxAttempts = 100;
            int attemptCount = 0;

            while (attemptCount < maxAttempts)
            {
                int newId = random.Next(1, int.MaxValue);
                if (!repository.GetCarts().Any(c => c.Id == newId))
                    return newId;

                attemptCount++;
            }

            return 0;
        }

        public int GetUniqueLikedId(StreetStuffContext db)
        {
            throw new NotImplementedException();
        }

        public void MinusQuantity(int id)
        {
            Cart? cart = repository.GetCartById(id);
            cart.Quantity--;
            repository.SaveChanges();
        }

        public void RemoveFromBasket(Cart cart)
        {
            repository.RemoveFromBasket(cart);
        }

        public void RemoveProductFromLiked(Liked liked)
        {
            repository.RemoveProductFromLiked(liked);
        }

        
    }
}
