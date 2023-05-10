using ClinicCentres.Core.DomainEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Repostories.BranchRepository
{
    public interface IBranchRepository
    {
        Task<List<Branch>> GetAllBranches();
        Task<int> AddEditBranch(Branch branch);
        Task<Branch> GetBranchById(int id);
        Task<bool> DeleteBranchById(int id);
    }
}
