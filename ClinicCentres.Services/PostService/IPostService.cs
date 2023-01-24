using ClinicCentres.Core.DomainEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Services.PostServices
{
    public interface IPostService
    {
        Task<int> AddPostAsync(Post post);
        Task<List<Post>> GetPostsByCategoryAsync(int id);
    }
}
