using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Models
{
    public class CategoryModel
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }
    }
}
