using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Repostories.BranchRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Services.BranchService
{
    public class BranchService : IBranchService
    {
        private readonly IBranchRepository branchRepository;

        public BranchService(IBranchRepository branchRepository)
        {
            this.branchRepository = branchRepository;
        }
        public async Task<int> AddEditBranch(Branch branch)
        {
            return await branchRepository.AddEditBranch(branch);
        }

        public async Task<List<Branch>> GetAllBranches()
        {
            return await branchRepository.GetAllBranches();
        }

        public async Task<Branch> GetBranchById(int id)
        {
            return await branchRepository.GetBranchById(id);
        }

        public async Task<bool> DeleteBranchById(int id)
        {
            return await branchRepository.DeleteBranchById(id);
        }
    }
}
