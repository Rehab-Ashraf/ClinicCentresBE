using AutoMapper;
using ClinicCentres.Models;
using ClinicCentres.Services.CategoryService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;
using ClinicCentres.Core.DomainEntities;

namespace ClinicCentres.Web.Api.CategoryContainer
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class CategoryController : ControllerBase
    {
        private readonly ICategoryService CategoryService;
        private readonly IMapper mapper;

        public CategoryController(ICategoryService CategoryService, IMapper mapper)
        {
            this.CategoryService = CategoryService;
            this.mapper = mapper;
        }

        [HttpPost]
        [Authorize(Policy = ("AddCategory"))]
        public async Task<IActionResult> AddCategory(CategoryModel Category)
        {
            var CategoryModel = mapper.Map<Category>(Category);
            var result = await CategoryService.AddEditCategory(CategoryModel);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllCategoryes()
        {
            var Categoryes = await CategoryService.GetAllCategories();
            var countryModel = mapper.Map<List<CategoryModel>>(Categoryes);
            return Ok(ResponseResult.SucceededWithData(countryModel));
        }

        [HttpDelete]
        [Authorize(Policy = ("DeleteCategory"))]
        public async Task<IActionResult> DeleteCategory(int id)
        {
            var result = await CategoryService.DeleteCategoryById(id);
            return Ok(ResponseResult.SucceededWithData(result));
        }
    }
}
