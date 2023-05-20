using ClinicCentres.Core.DomainEntities.Entities;
using ClinicCentres.Repostories.ImageRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Services.ImageService
{
    public class ImageService : IImageService
    {
        private readonly IImageRepository imageRepository;

        public ImageService(IImageRepository imageRepository)
        {
            this.imageRepository = imageRepository;
        }
        public async Task<int> AddEditImage(Image image)
        {
            return await imageRepository.AddEditImage(image);
        }

        public async Task<bool> DeleteImageById(int id)
        {
            return await imageRepository.DeleteImageById(id);
        }

        public async Task<List<Image>> GetAllImagesByPostId(int postId)
        {
            return await imageRepository.GetAllImagesByPostId(postId);
        }

        public async Task<Image> GetImageById(int id)
        {
            return await imageRepository.GetImageById(id);
        }
    }
}
