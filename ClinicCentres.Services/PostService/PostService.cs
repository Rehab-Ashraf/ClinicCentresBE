using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Repostories.PostRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Services.PostServices
{
    public class PostService : IPostService
    {
        private readonly IPostRepository _postRepository;

        public PostService(IPostRepository postRepository)
        {
            _postRepository = postRepository;
        }
        public async Task<int> AddPostAsync(Post post)
        {
            return await _postRepository.AddPostAsync(post);
        }

        public async Task<List<Post>> GetPostsByCategoryAsync(int categoryId)
        {
            return await _postRepository.GetPostsByCategoryAsync(categoryId);
        }
    }
}
