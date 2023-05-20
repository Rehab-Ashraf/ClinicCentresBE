using ClinicCentres.Core.DomainEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Repostories.CategoryRepository
{
    public interface ICategoryRepository
    {
        Task<List<Category>> GetAllCategories();
        Task<int> AddEditCategory(Category Category);
        Task<bool> DeleteCategoryById(int id);
    }
}
