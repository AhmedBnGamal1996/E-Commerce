using Domain.Exceptions;
using Shared.Shared.ErrorModels;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace E_Commerce.API.Middlewares
{
    public class GlobalExceptionHandlingMiddleware
    {
        private readonly RequestDelegate _next; 
        private readonly ILogger<GlobalExceptionHandlingMiddleware> _logger;
        public GlobalExceptionHandlingMiddleware(RequestDelegate next ,
            ILogger<GlobalExceptionHandlingMiddleware>logger)
        {
            _next = next;
            _logger = logger;
        }

        public async Task InvokeAsync(HttpContext context)
        {
            try
            {
                await _next(context);
                if (context.Response.StatusCode == StatusCodes.Status404NotFound)
                    await HandleNotFoundApiAsync(context); 

            }
            catch (Exception ex)
            {
                _logger.LogError($"SomeThing went wrong ==> : {ex.Message}");

                await HandleExceptionAsync(context, ex); 






            }







        }

        private async Task HandleNotFoundApiAsync(HttpContext context)
        {
            context.Response.ContentType = "application/json";

            var response = new ErrorDetails()
            {
                StatusCode = StatusCodes.Status400BadRequest,
                ERrorMessage = $"The endpoint with url {context.Request.Path} not found "
            }.ToString();
            await context.Response.WriteAsync(response);

        }







        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            //  context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // context.Response.StatusCode = StatusCodes.Status500InternalServerError;
            


            context.Response.ContentType = "application/json";


            var response = new ErrorDetails()
            {

                ERrorMessage = ex.Message
            };



            context.Response.StatusCode = ex switch
            {

                NotFoundException => StatusCodes.Status404NotFound,
                UnauthorizedAccessException => StatusCodes.Status401Unauthorized ,
                VlaidationException validationException => HandleValidationException(validationException , response),
                (_) => StatusCodes.Status500InternalServerError, 


            
            
            
            };


                
            



            response.StatusCode = context.Response.StatusCode; 

            await context.Response.WriteAsync(response.ToString()); 






        }

        private int HandleValidationException(VlaidationException validationException, ErrorDetails response)
        {
            response.Errors = validationException.Errors; 
            
            return StatusCodes.Status400BadRequest;







        }
    }
}
