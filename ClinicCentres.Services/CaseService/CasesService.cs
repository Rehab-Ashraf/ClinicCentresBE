using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Repostories.CaseRepository;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Services.CaseService
{
    public class CasesService : ICasesService
    {
        private readonly ICasesRepository _caseRepository;

        public CasesService(ICasesRepository caseRepository)
        {
            _caseRepository = caseRepository;
        }

        public async Task<int> AddEditCase(Case caseInput)
        {
            return await _caseRepository.AddEditCase(caseInput);
        }

        public async Task<bool> DeleteCaseById(int id)
        {
            return await _caseRepository.DeleteCaseById(id);
        }

        public async Task<List<Case>> GetAllCases()
        {
            return await _caseRepository.GetAllCases();
        }

        public async Task<List<Case>> GetAllCasesBasicDetails()
        {
            return await _caseRepository.GetAllCasesBasicDetails();
        }
    }
}
