using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Models
{
    public class PostModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public string VideoURL { get; set; }
        public IList<byte[]> Images { get; set; }
        public DateTime PublishingTime { get; set; }
        public int CategoryId { get; set; }
        public string UserId { get; set; }

        public static PostModel New(int id, string description, IList<byte[]> images, DateTime publishingTime, int categoryId,string userId)
        {
            return new PostModel
            {
                Id = id,
                Description = description,
                Images = images,
                PublishingTime = publishingTime,
                CategoryId = categoryId,
                UserId = userId
            };
        }
    }
}
