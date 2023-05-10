using ClinicCentres.Core.DomainEntities;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Services.CaseService
{
    public interface ICasesService
    {
        Task<List<Case>> GetAllCases();
        Task<int> AddEditCase(Case caseInput);
        Task<bool> DeleteCaseById(int id);
        Task<List<Case>> GetAllCasesBasicDetails();
    }
}
