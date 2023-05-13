using AutoMapper;
using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Models;
using ClinicCentres.Models.Branches;
using ClinicCentres.Services.BranchService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Web.Api.BranchContainer
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class BranchController : ControllerBase
    {
        private readonly IBranchService branchService;
        private readonly IMapper mapper;

        public BranchController(IBranchService branchService, IMapper mapper)
        {
            this.branchService = branchService;
            this.mapper = mapper;
        }

        [Authorize(Policy = ("AddBranch"))]
        [HttpPost]
        public async Task<IActionResult> AddBranch(BranchModel branch)
        {
            var branchModel = mapper.Map<Branch>(branch);
            var result = await branchService.AddEditBranch(branchModel);
            return Ok(result);
        }
        [AllowAnonymous]
        [HttpGet]
        public async Task<IActionResult> GetAllBranches()
        {
            var branches = await branchService.GetAllBranches();
            var countryModel = mapper.Map<List<BranchModel>>(branches);
            return Ok(ResponseResult.SucceededWithData(countryModel));
        }

        [Authorize(Policy = ("RequireSuperAdminRole"))]
        [HttpDelete]
        public async Task<IActionResult> DeleteBranch(int id)
        {
            var result =  await branchService.DeleteBranchById(id);
            return Ok(ResponseResult.SucceededWithData(result));
        }

    }
}
