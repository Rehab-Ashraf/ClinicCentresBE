using AutoMapper;
using ClinicCentres.Services.PostServices;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;
using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Models;
using Microsoft.AspNetCore.Authorization;

namespace ClinicCentres.Web.Api.PostContainer
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class PostController : ControllerBase
    {
        private readonly IPostService postService;
        private readonly IMapper mapper;

        public PostController(IPostService postService, IMapper mapper)
        {
            this.postService = postService;
            this.mapper = mapper;
        }

        [HttpPost]
        public async Task<IActionResult> AddPostAsync(PostModel model)
        {
            var post = mapper.Map<Post>(model);
            
            var result = await postService.AddPostAsync(post);

            return Ok(result);

        }
        
    }
}
