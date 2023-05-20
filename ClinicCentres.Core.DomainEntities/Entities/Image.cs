﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Core.DomainEntities.Entities
{
    public class Image
    {
        public int Id { get; set; }
        public byte[] ImageBytes { get; set; }
        public virtual Post Post { get; set; }
        public int? PostId { get; set; }
        public virtual Product Product { get; set; }
        public int? ProductId { get; set; }
        public virtual Category Category { get; set; }
        public int CategoryId { get; set; }
    }
}
