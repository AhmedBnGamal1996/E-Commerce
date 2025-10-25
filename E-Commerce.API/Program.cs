
using Domain.Contracts;
using E_Commerce.API.Extensions;
using E_Commerce.API.Factories;
using E_Commerce.API.Middlewares;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Presistence.Data;
using Presistence.Repositories;
using Services;
using Services.Implementations;
using ServicesAbstraction.Contracts;

namespace E_Commerce.API
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            #region DI Container


            var builder = WebApplication.CreateBuilder(args);

            //WebApiServices

            builder.Services.AddWebApiServices();



            // Infrastructure Services


            builder.Services.AddInfrastructureServices(builder.Configuration);

            // Core Services
            builder.Services.AddCoreServices();




            #endregion


            #region  Pipeline


            var app = builder.Build();

            await app.SeedDatabaseAsync();



            app.UseExceptionsHandlingMiddlewares();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {

                app.UseSwaggerMiddlewares();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.MapControllers();

            app.Run();


            #endregion 



            
        }
    }
}
 