
using ClinicCentres.Core.DomainEntities.Entities;
using System.Collections.Generic;

namespace ClinicCentres.Core.DomainEntities
{
    public class Product
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public decimal Cost { get; set; }
        public decimal Price { get; set; }
        public ICollection<Image> Images { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
