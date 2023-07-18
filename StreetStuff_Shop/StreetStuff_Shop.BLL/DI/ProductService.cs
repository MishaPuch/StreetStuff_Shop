
using Microsoft.EntityFrameworkCore.Metadata;
using StreetStuff_Shop.BLL.Interfaces;
using StreetStuff_Shop.DAL.RepositoriumsInterface;
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
        private IRepositoryLiked likedRepository;
        private IRepositoryCarts cartRepository;
        private IRepositoryProducts productRepository;
        private IRepositoryUsers userRepository;

        public ProductService(IRepositoryLiked likedRepository , IRepositoryCarts cartRepository, IRepositoryProducts productRepository, IRepositoryUsers userRepository)
        {
            this.likedRepository = likedRepository;
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
        }
       

        public async Task AddQuantity(int id)
        {
            Cart cart = await cartRepository.GetCartById(id);
            cart.Quantity++;
            likedRepository.SaveChanges();


        }

        public void AddToBasket(int UserId, int ProductId)
        {

            var cart = new Cart();
            bool isIdUnique = false;

            do
            {
                cart.Id = GenerateUniqueCartId();
                if (cart.Id > 0)
                    isIdUnique = cartRepository.GetCartById(cart.Id) == null;
            }
            while (!isIdUnique);

            cart.ProductId = ProductId;
            cart.UserId = UserId;
            cart.Quantity = 1;

            cartRepository.AddCart(cart);

        }

        public async Task ChangeQuantity(int id, int quantity)
        {
            Cart cart = await cartRepository.GetCartById(id);
            cart.Quantity = quantity;
        }

        public int GenerateUniqueCartId()
        {
            int maxAttempts = 100;
            int attemptCount = 0;

            while (attemptCount < maxAttempts)
            {
                int newId = new Random().Next(1, int.MaxValue);
                if (cartRepository.GetCartById(newId) == null)
                    return newId;

                attemptCount++;
            }

            return 0;
        }
        public async Task<List<Product>> GetProducts()
        {
            return await productRepository.GetProducts();
        }

        public async Task MinusQuantity(int id)
        {
            Cart cart =await cartRepository.GetCartById(id);
            cart.Quantity--;
            likedRepository.SaveChanges();
        }

        public void RemoveFromBasket(Cart cart)
        {
            cartRepository.RemoveFromCart(cart);
        }

        public void RemoveProductFromLiked(Liked liked)
        {
            likedRepository.RemoveProductFromLiked(liked);
        }

       
    }
}
