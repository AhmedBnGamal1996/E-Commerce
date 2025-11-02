using Shared.Dtos.IdentityModule;
using Shared.Dtos.OrderModule;
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



        // Get Current User 

        Task<UserResultDto> GetCurrentUserAsync(string userEmail); 




        // Check If email Exist 
        Task<bool> CheckEmailExistAsync(string userEmail);



        // Get Address 

        Task<AddressDto> GetUserAddressAsync(string userEmail);




        // Update Address

        Task<AddressDto> UpdateUserAddressAsync(string userEmail , AddressDto addressDto);





















    }
}
