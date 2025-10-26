using Domain.Entities.IdentityModule;
using Domain.Exceptions;
using Microsoft.AspNetCore.Identity;
using ServicesAbstraction.Contracts;
using Shared.Dtos.IdentityModule;


namespace Services.Implementations
{
    internal class AuthenticationService(UserManager<User> _userManager) : IAuthenticationService
    {


        public async Task<UserResultDto> LoginAsync(LoginDto loginDto)
        {
            var user = await _userManager.FindByEmailAsync(loginDto.Email);

            if (user is null) throw new UnauthorizedException() ; 
            
            var result = await _userManager.CheckPasswordAsync(user, loginDto.Password);

            if (!result) throw new UnauthorizedException();
            return new UserResultDto(user.DisplayName, "Token", user.Email); 













        }




        public async Task<UserResultDto> RegisterAsync(RegisterDto registerDto)
        {

            var user = new User
            {
                DisplayName = registerDto.DisplayName,
                Email = registerDto.Email,
                UserName = registerDto.DisplayName,
                PhoneNumber = registerDto.PhoneNumber
            };
            var result = await _userManager.CreateAsync(user, registerDto.Password);

            if (!result.Succeeded)
            {
                var errors = result.Errors.Select(e=>e.Description) .ToList ();

                throw new VlaidationException(errors);



                
            }





        }



    }
}
