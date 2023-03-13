using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Repostories.PostRepostory
{
    public class PostRepository : IPostRepository
    {
        private readonly ClinicCentresDbContext clinicCentresDbContext;

        public PostRepository(ClinicCentresDbContext clinicCentresDbContext)
        {
            this.clinicCentresDbContext = clinicCentresDbContext;
        }
        public async Task<int> AddPostAsync(Post post)
        {
            await clinicCentresDbContext.AddAsync(post);
            await clinicCentresDbContext.SaveChangesAsync();
            return post.Id;
        }

        public async Task<List<Post>> GetPostsByCategoryAsync(int categoryId)
        {
            return await clinicCentresDbContext.Posts.Where(x => x.CategoryId == categoryId).ToListAsync();
        }
    }
}
