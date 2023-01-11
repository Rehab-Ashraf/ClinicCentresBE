using System;
using System.Collections.Generic;

namespace ClinicCentres.Core.DomainEntities
{
    public class Comment
    {
        public int Id { get; set; }
        public string Description { get; set; }
        public DateTime DateTime { get; set; }
        public int? ParentId { get; set; }
        public ICollection<Comment> Replies { get; set; }
        public ICollection<Like> Likes { get; set; }
        public int PostId { get; set; }
        public Post Post { get; set; }
    }
}
