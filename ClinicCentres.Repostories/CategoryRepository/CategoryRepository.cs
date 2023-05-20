using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Repostories.CategoryRepository
{
    public class CategoryRepository : ICategoryRepository
    {
        private readonly ClinicCentresDbContext _clinicCentresDbContext;

        public CategoryRepository(ClinicCentresDbContext clinicCentresDbContext)
        {
            _clinicCentresDbContext = clinicCentresDbContext;
        }
        public async Task<int> AddEditCategory(Category category)
        {
            try
            {
                if(category.Id <= 0)
                {
                    category.IsActive = true;
                    category.ParentId = null;
                    await _clinicCentresDbContext.AddAsync(category);
                    await _clinicCentresDbContext.SaveChangesAsync();
                }
                else if (category.Id > 0)
                {
                    var branchToBeUpdate = GetCategoryById(category.Id);
                    if (branchToBeUpdate == null)
                        return -1;
                    category.IsActive = true;
                    _clinicCentresDbContext.Update<Category>(category);
                    await _clinicCentresDbContext.SaveChangesAsync();
                }
            }
            catch (Exception ex)
            {

                throw ex;
            }
            return category.Id;
        }

        public async Task<bool> DeleteCategoryById(int id)
        {
            var categoryToDelete = GetCategoryById(id).Result;
            if (categoryToDelete == null)
                return false;
            categoryToDelete.IsActive = false;
            _clinicCentresDbContext.Update<Category>(categoryToDelete);
            await _clinicCentresDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Category>> GetAllCategories()
        {
            return await _clinicCentresDbContext.Categories
                .Where(b => b.IsActive == true)
                .Select(b => new Category() { Id = b.Id, Description = b.Description })
                .ToListAsync();
        }

        public async Task<Category> GetCategoryById(int id)
        {
            return await _clinicCentresDbContext.Categories
                                .Where(b => b.Id == id)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
        }
    }
}
