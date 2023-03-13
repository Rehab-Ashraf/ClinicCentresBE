using ClinicCentres.Core.DomainEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Repostories.BranchRepostory
{
    public interface IBranchRepostory
    {
        Task<List<Branch>> GetAllBranches();
        Task<int> AddEditBranch(Branch branch);
        Task<Branch> GetBranchById(int id);
        Task<bool> DeleteBranchById(int id);
    }
}
