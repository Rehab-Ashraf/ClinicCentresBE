using ClinicCentres.Core.DomainEntities.Entities;
using ClinicCentres.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Repostories.ImageRepository
{
    public class ImageRepository : IImageRepository
    {
        private readonly ClinicCentresDbContext _clinicCentresDbContext;

        public ImageRepository(ClinicCentresDbContext clinicCentresDbContext)
        {
            _clinicCentresDbContext = clinicCentresDbContext;
        }
        public async Task<int> AddEditImage(Image image)
        {
            if (image.Id <= 0)
            {
                await _clinicCentresDbContext.AddAsync(image);
                await _clinicCentresDbContext.SaveChangesAsync();
            }
            else if (image.Id > 0)
            {
                var imageToBeUpdate = GetImageById(image.Id);
                if (imageToBeUpdate == null)
                    return -1;
                _clinicCentresDbContext.Update<Image>(image);
                await _clinicCentresDbContext.SaveChangesAsync();
            }
            return image.Id;
        }

        public async Task<bool> DeleteImageById(int id)
        {
            var imageToDelete = GetImageById(id).Result;
            if (imageToDelete == null)
                return false;
            _clinicCentresDbContext.Images.Remove(imageToDelete);
            await _clinicCentresDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Image>> GetAllImagesByPostId(int postId)
        {
            return await _clinicCentresDbContext.Images
                        .Where(b => b.PostId == postId)
                        .Select(b => new Image() 
                        { 
                            Id = b.Id, 
                            ImageBytes = b.ImageBytes
                        }).ToListAsync();
        }

        public async Task<Image> GetImageById(int id)
        {
            return await _clinicCentresDbContext.Images
                                .Where(b => b.Id == id)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
        }
    }
}
