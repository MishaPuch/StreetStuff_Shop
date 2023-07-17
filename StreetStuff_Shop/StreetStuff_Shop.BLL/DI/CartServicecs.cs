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
        public void AddCart(Cart cart)
        {
            cartRepository.AddCart(cart);
        }

        public void AddToCart(int UserId, int ProductId)
        {

            Cart cart = new Cart();
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

        public int GenerateUniqueCartId()
        {
            return cartRepository.GetUniqueCartId();
        }

        public Cart GetCart(int id)
        {
            return cartRepository.GetCart(id);
        }

        public Cart? GetCartById(int CartId)
        {
            return cartRepository.GetCartById(CartId);
        }

        public Cart? GetCartById(int ProductId, int UserId)
        {
            return cartRepository.GetCartById(ProductId, UserId);
        }

        public List<Cart> GetCarts()
        {
            return cartRepository.GetCarts();
        }

        public void RemoveFromCart(Cart cart)
        {
            cartRepository.RemoveFromCart(cart);
        }
    }
}
