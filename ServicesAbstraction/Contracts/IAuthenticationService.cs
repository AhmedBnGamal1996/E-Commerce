using Shared.Dtos.IdentityModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesAbstraction.Contracts
{
    public interface IAuthenticationService
    {

        // Login ==> return IserResultDto  => Take Parameters

        Task<UserResultDto> LoginAsync(LoginDto loginDto);



        // Register => return UserResultDto ==> Take Parameters


        Task<UserResultDto> RegisterAsync(RegisterDto registerDto);







    }
}
