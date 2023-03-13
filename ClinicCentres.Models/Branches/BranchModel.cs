using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Models.Branches
{
    public class BranchModel
    {
        public int Id { get; set; }
        public string Description { get; set; }

        public static PostModel New(int id, string description)
        {
            return new PostModel
            {
                Id = id,
                Description = description,
            };
        }

    }
}
