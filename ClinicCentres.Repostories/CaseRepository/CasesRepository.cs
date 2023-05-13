using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Data.EF;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ClinicCentres.Repostories.CaseRepository
{
    public class CasesRepository : ICasesRepository
    {
        private readonly ClinicCentresDbContext clinicCentresDbContext;

        public CasesRepository(ClinicCentresDbContext clinicCentresDbContext)
        {
            this.clinicCentresDbContext = clinicCentresDbContext;
        }
        public async Task<Case> GetCaseById(int id)
        {
            return await clinicCentresDbContext.Cases
                                .Where(b => b.Id == id)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
        }

        public async Task<Case> GetCaseByPhone(string phoneNumber)
        {
            return await clinicCentresDbContext.Cases
                                .Where(b => b.PhoneNumber == phoneNumber)
                                .AsNoTracking()
                                .FirstOrDefaultAsync();
        }
        public async Task<int> AddEditCase(Case caseInput)
        {
            //case id will be zero or less to add
            if (caseInput.Id <= 0)
            {
                //check if this user exist before adding 
                var caseExist = GetCaseByPhone(caseInput.PhoneNumber);
                if(caseExist.Result != null && !caseExist.Result.IsActive)
                    return -2; //it means this user has been deactivated and needs admin to re-activate 
                
                if (caseExist.Result != null && caseExist.Result.IsActive)
                    return caseExist.Result.Id;//return case id if it already exist

                caseInput.IsActive = true;
                await clinicCentresDbContext.AddAsync(caseInput);
                await clinicCentresDbContext.SaveChangesAsync();
            }
            //case id will be greater than zero to edit
            else if (caseInput.Id > 0)
            {
                var branchToBeUpdate = GetCaseById(caseInput.Id);
                if (branchToBeUpdate == null)
                    return -1;//there is no case with this id exist to update
                caseInput.IsActive = true;
                clinicCentresDbContext.Update<Case>(caseInput);
                await clinicCentresDbContext.SaveChangesAsync();
            }
            return caseInput.Id;
        }

        public async Task<bool> DeleteCaseById(int id)
        {
            var caseToDelete =  await GetCaseById(id);
            if (caseToDelete == null)
                return false;
            caseToDelete.IsActive = false;
            clinicCentresDbContext.Update<Case>(caseToDelete);
            await clinicCentresDbContext.SaveChangesAsync();
            return true;
        }

        public async Task<List<Case>> GetAllCases()
        {
            return await clinicCentresDbContext.Cases
                .Where(b => b.IsActive == true)
                .Select(b => new Case() 
                { 
                    Id = b.Id,
                    PhoneNumber = b.PhoneNumber,
                    DateOfBirth = b.DateOfBirth,
                    Email = b.Email,
                    Name = b.Name,
                }).ToListAsync();
        }

        public async Task<List<Case>> GetAllCasesBasicDetails()
        {
            return await clinicCentresDbContext.Cases
                .Where(b => b.IsActive == true)
                .Select(b => new Case()
                {
                    Id = b.Id,
                    PhoneNumber = b.PhoneNumber,
                    Name = b.Name
                }).ToListAsync();
        }
    }
}
