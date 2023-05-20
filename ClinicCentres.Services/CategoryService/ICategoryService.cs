using ClinicCentres.Core.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Services.CategoryService
{
    public interface ICategoryService
    {
        Task<List<Category>> GetAllCategories();
        Task<int> AddEditCategory(Category branch);
        Task<bool> DeleteCategoryById(int id);
    }
}
