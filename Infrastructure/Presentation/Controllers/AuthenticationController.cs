using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction.Contracts;
using Shared.Dtos.IdentityModule;



namespace Presentation.Controllers
{
    public class AuthenticationController(IServiceManager _serviceManager ) : ApiController
    {

        // Post ==> Register 

        [HttpPost("Register")]
        public async Task<ActionResult<UserResultDto>> RegisterAsync (RegisterDto registerDto)
        => Ok(await _serviceManager.AuthenticationService.RegisterAsync(registerDto));






         



        // Post ==> Login 

        [HttpPost("Login")]

        public async Task<ActionResult<UserResultDto>> LoginAsync(LoginDto loginDto) 
            => Ok(await _serviceManager.AuthenticationService.LoginAsync(loginDto));



















    }
}
