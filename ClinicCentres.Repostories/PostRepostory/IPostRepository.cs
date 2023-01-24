
using ClinicCentres.Core.DomainEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Repostories.PostRepostory
{
    public interface IPostRepository
    {
        Task<int> AddPostAsync(Post post);
        Task<List<Post>> GetPostsByCategoryAsync(int categoryId);
    }
}
