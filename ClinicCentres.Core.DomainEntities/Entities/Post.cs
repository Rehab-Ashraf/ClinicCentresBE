using ClinicCentres.Core.DomainEntities.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicCentres.Core.DomainEntities
{
    public class Post
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime PublishingTime { get; set; }
        public int CategoryId { get; set; }
        public virtual Category Category { get; set; }
        public ICollection<Comment> Comments { get; set; }
        public ICollection<Like> Likes { get; set; }
        public ICollection<Image> Images { get; set; }
    }
}
