using System;
using System.Collections.Generic;
using System.Text;

namespace ClinicCentres.Core.DomainEntities
{
    public class Like
    {
        public int Id { get; set; }
        public Post Post { get; set; }
        public int PostId { get; set; }
        public Comment Comment { get; set; }
        public int CommentId { get; set; }
    }
}
