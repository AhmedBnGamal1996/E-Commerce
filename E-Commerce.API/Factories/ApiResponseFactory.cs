using Microsoft.AspNetCore.Mvc;
using Shared.Shared.ErrorModels;

namespace E_Commerce.API.Factories
{
    public class ApiResponseFactory
    {

        public static IActionResult CustomValidationErrorResponse(ActionContext context)
        {
            var error = context.ModelState.
                Where(error => error.Value?.Errors.Any() == true ).Select(error => new ValidationError()
                {
                    Field = error.Key,
                     Errors = error.Value?.Errors.Select(error => error.ErrorMessage)
                     ?? new List<string>()



                });

            var response = new ValidationErrorResponse()
            {
                Errors = error , 
                StatusCode = StatusCodes.Status400BadRequest , 
                ErrorMessage = "One or more validation erro happened "
            };

            return new BadRequestObjectResult(response); 




        }







    }
}
