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
        public void AddLiked(Liked liked)
        {
            likedRepository.AddLiked(liked);
        }

        public void AddProductToLiked(int ProductId, int UserId)
        {
           
                Liked liked = new Liked();
                bool isIdUnique = false;

                do
                {
                    liked.Id = likedRepository.GetUniqueLikedId();
                    if (liked.Id > 0)
                        isIdUnique = likedRepository.GetLikedById(liked.Id, UserId) == null;
                }
                while (!isIdUnique);

                liked.ProductId = ProductId;
                liked.UserId = UserId;

                likedRepository.AddLiked(liked);
                        
        }

        public IEnumerable<Liked>? GetAllLikedProducts()
        {
            return likedRepository.GetAllLikedProducts();
        }

        public Liked GetLikedById(int ProductId, int UserId)
        {
            return likedRepository.GetLikedById(ProductId, UserId);
        }

        public void RemoveProductFromLiked(Liked liked)
        {
            likedRepository.RemoveProductFromLiked(liked);
        }

        public void SaveChanges()
        {
            likedRepository.SaveChanges();
        }
    }
}
