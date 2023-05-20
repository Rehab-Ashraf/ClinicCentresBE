using ClinicCentres.Core.DomainEntities.Entities;
using System.Collections.Generic;

namespace ClinicCentres.Core.DomainEntities
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int ImageId { get; set; }
        public virtual Image Image { get; set; }
        public ICollection<Post> Posts { get; set; }
        public int? ParentId { get; set; }
        public ICollection<Category> Subcategories { get; set; }
        public ICollection<Product> Products { get; set; }
        public bool IsActive { get; set; }
    }
}
