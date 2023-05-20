using AutoMapper;
using ClinicCentres.Core.DomainEntities.Entities;
using ClinicCentres.Models;
using ClinicCentres.Models.Images;
using ClinicCentres.Services.ImageService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Web.Api.ImageContainer
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class ImageController : ControllerBase
    {
        private readonly IImageService imageService;
        private readonly IMapper mapper;

        public ImageController(IImageService imageService, IMapper mapper)
        {
            this.imageService = imageService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize(Policy = ("AddImage"))]
        public async Task<IActionResult> AddEditImage(ImagesModel imageModel)
        {
            var image = mapper.Map<Image>(imageModel);
            var result = await imageService.AddEditImage(image);
            return Ok(result);
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetAllImagesByPostId")]
        public async Task<IActionResult> GetAllImagesByPostId(int id)
        {
            var images = await imageService.GetAllImagesByPostId(id);
            var countryModel = mapper.Map<List<ImagesModel>>(images);
            return Ok(ResponseResult.SucceededWithData(countryModel));
        }

        [AllowAnonymous]
        [HttpGet]
        [Authorize(Policy = ("GetImage"))]
        [Route("GetImageById")]
        public async Task<IActionResult> GetImageById(int id)
        {
            var images = await imageService.GetImageById(id);
            var countryModel = mapper.Map<List<ImagesModel>>(images);
            return Ok(ResponseResult.SucceededWithData(countryModel));
        }

        [HttpDelete]
        [Authorize(Policy = ("DeleteImage"))]
        public async Task<IActionResult> DeleteImage(int id)
        {
            var result = await imageService.DeleteImageById(id);
            return Ok(ResponseResult.SucceededWithData(result));
        }
    }
}