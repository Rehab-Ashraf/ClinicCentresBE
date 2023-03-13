﻿using ClinicCentres.Core.DomainEntities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ClinicCentres.Services.BranchService
{
    public interface IBranchService
    {
        Task<List<Branch>> GetAllBranches();
        Task<int> AddEditBranch(Branch branch);
        Task<Branch> GetBranchById(int id);
        Task<bool> DeleteBranchById(int id);
    }
}
