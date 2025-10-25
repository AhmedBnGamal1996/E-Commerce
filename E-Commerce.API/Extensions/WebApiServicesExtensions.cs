using E_Commerce.API.Factories;
using Microsoft.AspNetCore.Mvc;
using Services.Implementations;
using ServicesAbstraction.Contracts;

namespace E_Commerce.API.Extensions
{
    public static class WebApiServicesExtensions
    {


        public static IServiceCollection AddWebApiServices(this IServiceCollection services)
        {
             

            services.AddControllers();
            
            services.AddEndpointsApiExplorer();
            services.AddSwaggerGen();
            
            services.Configure<ApiBehaviorOptions>(option =>
            {
                option.InvalidModelStateResponseFactory = ApiResponseFactory.CustomValidationErrorResponse;

            });


            return services;

        }










    }
}
