using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Repostories.CategoryRepository;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Services.CategoryService
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository categoryRepository;

        public CategoryService(ICategoryRepository categoryRepository)
        {
            this.categoryRepository = categoryRepository;
        }
        public async Task<int> AddEditCategory(Category category)
        {
            return await categoryRepository.AddEditCategory(category);
        }

        public async Task<bool> DeleteCategoryById(int id)
        {
            return await categoryRepository.DeleteCategoryById(id);
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await categoryRepository.GetAllCategories();
        }
    }
}
