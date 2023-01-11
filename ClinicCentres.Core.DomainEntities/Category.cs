using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicCentres.Core.DomainEntities
{
    public class Category
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public ICollection<Post> Posts { get; set; }
        public int? ParentId { get; set; }
        public ICollection<Category> Subcategories { get; set; }
        public ICollection<Product> Products { get; set; }
    }
}
