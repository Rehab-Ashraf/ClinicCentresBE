using ClinicCentres.Core.DomainEntities.Entities;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Services.ImageService
{
    public interface IImageService
    {
        Task<List<Image>> GetAllImagesByPostId(int postId);
        Task<int> AddEditImage(Image image);
        Task<Image> GetImageById(int id);
        Task<bool> DeleteImageById(int id);
    }
}
