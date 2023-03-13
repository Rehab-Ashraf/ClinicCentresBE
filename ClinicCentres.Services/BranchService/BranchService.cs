using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Repostories.BranchRepostory;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Services.BranchService
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepostory branchRepostory;

        public BranchService(IBranchRepostory branchRepostory)
        {
            this.branchRepostory = branchRepostory;
        }
        public async Task<int> AddEditBranch(Branch branch)
        {
            return await branchRepostory.AddEditBranch(branch);
        }

        public async Task<List<Branch>> GetAllBranches()
        {
            return await branchRepostory.GetAllBranches();
        }

        public async Task<Branch> GetBranchById(int id)
        {
            return await branchRepostory.GetBranchById(id);
        }

        public async Task<bool> DeleteBranchById(int id)
        {
            return await branchRepostory.DeleteBranchById(id);
        }
    }
}
