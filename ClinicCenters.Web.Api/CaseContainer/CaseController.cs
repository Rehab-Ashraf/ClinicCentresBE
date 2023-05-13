using AutoMapper;
using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Models;
using ClinicCentres.Models.Cases;
using ClinicCentres.Services.CaseService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace ClinicCentres.Web.Api.CustomerContainer
{
    [Route("api/[controller]")]
    [ApiController]
    public class CaseController : ControllerBase
    {
        private readonly ICasesService caseService;
        private readonly IMapper mapper;

        public CaseController(ICasesService caseService, IMapper mapper)
        {
            this.caseService = caseService;
            this.mapper = mapper;
        }

        [Authorize(Policy = "AllCases")]
        [HttpGet]
        public async Task<IActionResult> GetAllCases()
        {
            var cases = await caseService.GetAllCases();
            var caseModel = mapper.Map<List<CasesModel>>(cases);
            return Ok(ResponseResult.SucceededWithData(caseModel));
        }

        [Authorize(Policy = "AllCases")]
        [HttpGet]
        [Route("GetAllCasesBasicDetails")]
        public async Task<IActionResult> GetAllCasesBasicDetails()
        {
            var cases = await caseService.GetAllCasesBasicDetails();
            var caseModel = mapper.Map<List<CaseBasicDetails>>(cases);
            return Ok(ResponseResult.SucceededWithData(caseModel));
        }

        [AllowAnonymous]
        [HttpPost]
        public async Task<IActionResult> AddEditCase(CasesModel casemodel)
        {
            var caseModel = mapper.Map<Case>(casemodel);
            var result = await caseService.AddEditCase(caseModel);
            if (result == -2)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"this user has been deactivated and needs admin to re-activate"));
            if (result == -1)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"there is no case with this {casemodel.Id} id exist to update"));
            return Ok(ResponseResult.SucceededWithData(result));
        }

        [Authorize(Policy = "DeleteCase")]
        [HttpDelete]
        public async Task<IActionResult> DeleteCase(int id)
        {
            var result = await caseService.DeleteCaseById(id);
            if (!result)
                return BadRequest(ResponseResult.Failed(ErrorCode.Error, $"There is no case with {id} id"));
            return Ok(ResponseResult.SucceededWithData(result));
        }
    }
}
