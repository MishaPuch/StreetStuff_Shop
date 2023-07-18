using StreetStuff_Shop.BLL.Interfaces;
using StreetStuff_Shop.DAL.RepositoriumsInterface;
using StreetStuff_Shop.DAL.RepositoriumsService;
using StreetStuff_Shop.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StreetStuff_Shop.BLL.DI
{
    public class LikedService : ILikedService
    {
        private IRepositoryLiked likedRepository;
        private IRepositoryCarts cartRepository;
        private IRepositoryProducts productRepository;
        private IRepositoryUsers userRepository;

        public LikedService(IRepositoryLiked likedRepository, IRepositoryCarts cartRepository, IRepositoryProducts productRepository, IRepositoryUsers userRepository)
        {
            this.likedRepository = likedRepository;
            this.cartRepository = cartRepository;
            this.productRepository = productRepository;
            this.userRepository = userRepository;
        }
        public async Task AddLiked(Liked liked)
        {
            await likedRepository.AddLiked(liked);
        }

        public async Task AddProductToLiked(int ProductId, int UserId)
        {

            var liked = new Liked();
            bool isIdUnique = false;

            do
            {
                liked.Id = await likedRepository.GetUniqueLikedId();
                if (liked.Id > 0)
                     
                 if(await likedRepository.GetLikedById(liked.Id, UserId) == null) 
                        isIdUnique = true;
            }
            while (!isIdUnique);

            liked.ProductId = ProductId;
            liked.UserId = UserId;

            await likedRepository.AddLiked(liked);

        }

        public async Task<IEnumerable<Liked>>? GetAllLikedProducts()
        {
            return await likedRepository.GetAllLikedProducts();
        }

        public async Task<Liked> GetLikedById(int ProductId, int UserId)
        {
            return await likedRepository.GetLikedById(ProductId, UserId);
        }

        public async Task RemoveProductFromLiked(Liked liked)
        {
            await likedRepository.RemoveProductFromLiked(liked);
        }

        public async Task SaveChanges()
        {
            await likedRepository.SaveChanges();
        }
    }
}
