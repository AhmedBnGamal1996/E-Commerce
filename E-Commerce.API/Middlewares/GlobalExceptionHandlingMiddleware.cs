using Domain.Exceptions;
using Shared.Shared.ErrorModels;
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

            }
            catch (Exception ex)
            {
                _logger.LogError($"SomeThing went wrong ==> : {ex.Message}");

                await HandleExceptionAsync(context, ex); 






            }







        }

        private async Task HandleExceptionAsync(HttpContext context, Exception ex)
        {

            //  context.Response.StatusCode = (int)HttpStatusCode.InternalServerError;

            // context.Response.StatusCode = StatusCodes.Status500InternalServerError;

            context.Response.StatusCode = ex switch
            {

                NotFoundException => StatusCodes.Status404NotFound,


                (_) => StatusCodes.Status500InternalServerError
            
            
            
            };


            context.Response.ContentType = "application/json";

            var response = new ErrorDetails()
            {
                StatusCode = context.Response.StatusCode,
                ERrorMessage = ex.Message
            }.ToString();


            await context.Response.WriteAsync(response); 






        }















    }
}
