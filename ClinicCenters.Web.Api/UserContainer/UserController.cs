using AutoMapper;
using ClinicCentres.Core.DomainEntities;
using ClinicCentres.Models;
using ClinicCentres.Models.Useres;
using ClinicCentres.Services.UserService;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using System.Threading.Tasks;


namespace ClinicCentres.Web.Api.UserContainer
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ControllerBase
    {
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public UserController(
            IUserService userService,
            IMapper mapper
            )
        {
            this.mapper = mapper;
            this.userService = userService;
        }
        [AllowAnonymous]
        [HttpPost]
        [Route("Register")]
        public async Task<IActionResult> RegisterAsync([FromBody] RegisterInputModel model)
        {
            var user = mapper.Map<User>(model);
            var result = await userService.RegisterAsync(user, model.Password);

            if (result.Succeeded)
            {
                return Ok(ResponseResult.SucceededWithData("User created successfully!"));
            }
            foreach (var error in result.Errors)
            {
                ModelState.AddModelError("Errors", error.Description);
            }
            return BadRequest(ModelState);
        }

        [HttpPost]
        [AllowAnonymous]
        [Route("Login")]
        public async Task<IActionResult> LoginAsync([FromBody] LoginInputModel model)
        {
            var result = await userService.LoginAsync(model.UserName, model.Password);

            if (result == null)
            {
                return BadRequest("Incorrect Email or Password");
            }
            var token = new
            {
                data = result
            };
            return Ok(token);

        }

        [HttpPost]
        [Route("Logout")]
        public async Task<IActionResult> Logout()
        {
            await userService.Logout();
            return Ok();
        }

        [AllowAnonymous]
        [HttpGet]
        [Route("GetUserById")]
        public async Task<IActionResult> GetUserById(string id)
        {
            var result = await userService.GetUserById(id);
            var user = mapper.Map<RegisterInputModel>(result);
            return Ok(ResponseResult.SucceededWithData(user));
        }
    }
}
