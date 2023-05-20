using ClinicCentres.Core.DomainEntities.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Repostories.ImageRepository
{
    public interface IImageRepository
    {
        Task<List<Image>> GetAllImagesByPostId(int postId);
        Task<int> AddEditImage(Image image);
        Task<Image> GetImageById(int id);
        Task<bool> DeleteImageById(int id);
    }
}
