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
    public class CartServicecs : ICartServicecs
    {
        private IRepositoryLiked likedRepository;
        private IRepositoryCarts cartRepository;
        private IRepositoryProducts productRepository;
        private IRepositoryUsers userRepository;

        public CartServicecs(IRepositoryLiked likedRepository, IRepositoryCarts cartRepository, IRepositoryProducts productRepository, IRepositoryUsers userRepository)
        {
            this.likedRepository = likedRepository;
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
        }
        public async Task AddCart(Cart cart)
        {
            await cartRepository.AddCart(cart);
        }

        public async Task AddToCart(int UserId, int ProductId)
        {

            var cart = new Cart();
            bool isIdUnique = false;

            do
            {
                cart.Id = await GenerateUniqueCartId();
                if (cart.Id > 0)
                isIdUnique =await cartRepository.GetCartById(cart.Id) == null;
            }
            while (!isIdUnique);

            cart.ProductId = ProductId;
            cart.UserId = UserId;
            cart.Quantity = 1;

            await cartRepository.AddCart(cart);
        }

        public async Task<int> GenerateUniqueCartId()
        {
            return await cartRepository.GetUniqueCartId();
        }

        public async Task<Cart> GetCart(int id)
        {
            return await cartRepository.GetCart(id);
        }

        public async Task<Cart>? GetCartById(int CartId)
        {
            return await cartRepository.GetCartById(CartId);
        }

        public async Task<Cart>? GetCartById(int ProductId, int UserId)
        {
            return await cartRepository.GetCartById(ProductId, UserId);
        }

        public async Task<List<Cart>> GetCarts()
        {
            return await cartRepository.GetCarts();
        }

        public async Task RemoveFromCart(Cart cart)
        {
            await cartRepository.RemoveFromCart(cart);
        }        
    }
}
