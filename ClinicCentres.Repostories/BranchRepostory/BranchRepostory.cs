using ClinicCentres.Core.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using ClinicCentres.Data.EF;

namespace ClinicCentres.Repostories.BranchRepostory
{
    public class BranchRepostory : IBranchRepostory
    {
        private readonly ClinicCentresDbContext _clinicCentresDbContext;

        public BranchRepostory(ClinicCentresDbContext clinicCentresDbContext)
        {
            _clinicCentresDbContext = clinicCentresDbContext;
        }
 
        public async Task<int> AddEditBranch(Branch branch)
        {
            if(branch.Id <= 0)
            {
                branch.IsActive = true;
                await _clinicCentresDbContext.AddAsync(branch);
                await _clinicCentresDbContext.SaveChangesAsync();
            }
            else if(branch.Id > 0)
            {
                var branchToBeUpdate = GetBranchById(branch.Id);
                if (branchToBeUpdate == null)
                    return -1;
                branch.IsActive = true;
                _clinicCentresDbContext.Update<Branch>(branch);
                await _clinicCentresDbContext.SaveChangesAsync();
            }
            return branch.Id;
        }


        public async Task<List<Branch>> GetAllBranches()
        {
            return await _clinicCentresDbContext.Branches
                .Where(b=>b.IsActive == true)
                .Select(b=>  new Branch() { Id = b.Id, Description = b.Description })
                .ToListAsync();
        }

        public async Task<Branch> GetBranchById(int id)
        {
            return await _clinicCentresDbContext.Branches
                                .Where(b => b.Id == id)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
        }

        public async Task<bool> DeleteBranchById(int id)
        {
            var branchToDelete = GetBranchById(id).Result;
            if (branchToDelete == null)
                return false;
            branchToDelete.IsActive = false;
            _clinicCentresDbContext.Update<Branch>(branchToDelete);
            await _clinicCentresDbContext.SaveChangesAsync();
            return true;
        }
    }
}
