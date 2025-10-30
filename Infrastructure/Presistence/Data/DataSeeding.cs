


using Domain.Entities.IdentityModule;
using Domain.Entities.OrderModule;
using Domain.Entities.ProductModule;
using Microsoft.AspNetCore.Identity;
using System.Text.Json;

namespace Presistence.Data
{
    public class DataSeeding(StoreDbContext _dbContext 
        , RoleManager<IdentityRole> _roleManager 
        , UserManager<User> _userManager) : IDataSeeding


    {
        public async Task SeedDataAsync()
        {

            // Check Any pending migrations ==> Apply Migrations

            try
            {
                var pendingMigrations = await _dbContext.Database.GetPendingMigrationsAsync();

                if (  pendingMigrations.Any() )

                {


                    await _dbContext.Database.MigrateAsync();


                }



                if (!_dbContext.ProductBrands.Any())

                {

                    var productBrandData =  File.OpenRead("..\\Infrastructure\\Presistence\\Data\\DataSeed\\brands.json");

                    // Json To C# Object

                    var productBrands = await JsonSerializer.DeserializeAsync<List<ProductBrand>>(productBrandData);

                    if (productBrands != null && productBrands.Any())
                    {
                        await _dbContext.ProductBrands.AddRangeAsync(productBrands);
                    }

                }



                if (!_dbContext.ProductTypes.Any())

                {

                    var productTypeData = File.OpenRead("..\\Infrastructure\\Presistence\\Data\\DataSeed\\types.json");

                    // Json To C# Object

                    var productTypes = await JsonSerializer.DeserializeAsync<List<ProductType>>(productTypeData);

                    if (productTypes != null && productTypes.Any())
                    {
                      await  _dbContext.ProductTypes.AddRangeAsync(productTypes);
                    }

                }



                if (!_dbContext.Products.Any())

                {

                    var productData = File.OpenRead("..\\Infrastructure\\Presistence\\Data\\DataSeed\\products.json");

                    // Json To C# Object

                    var products = await JsonSerializer.DeserializeAsync<List<Product>>(productData);

                    if (products != null && products.Any())
                    {
                       await _dbContext.Products.AddRangeAsync(products);
                    }


                }
                if (!_dbContext.DeliveryMethods.Any())
                {
                    var deliveryMethodData = File.OpenRead("..\\Infrastructure\\Presistence\\Data\\DataSeed\\delivery.json");
                    // Json To C# Object
                    var deliveryMethods = await JsonSerializer.DeserializeAsync<List<DeliveryMethod>>(deliveryMethodData);
                    if (deliveryMethods != null && deliveryMethods.Any())
                    {
                        await _dbContext.DeliveryMethods.AddRangeAsync(deliveryMethods);
                    }
                }

                    await  _dbContext.SaveChangesAsync();


            }


            catch (Exception ex)
            {
                // Handele the exception

            }








        }



        public async Task SeedIdentityDataAsync()
        {
            try
            {
                if (!_roleManager.Roles.Any())
                {
                    await _roleManager.CreateAsync(new IdentityRole("Admin"));

                    await _roleManager.CreateAsync(new IdentityRole("SuperAdmin"));
                    


                }
                if(!_userManager.Users.Any())
                {
                    var adminUser = new User()
                    {
                        DisplayName = "Admin" , 
                        UserName = "Admin", 
                        Email = "Admin@gmail.com" , 
                        PhoneNumber = "01098764532"
                    };

                    var superAdminUser = new User()
                    {
                        DisplayName = "SuperAdmin",
                        UserName = "SuperAdmin",
                        Email = "SuperAdmin@gmail.com",
                        PhoneNumber = "01098764530"
                    }; 

                    await _userManager.CreateAsync(adminUser , "P@ssw0rd");
                    await _userManager.CreateAsync(superAdminUser, "Pa$$w0rd");

                    await _userManager.AddToRoleAsync(adminUser, "Admin");
                    await _userManager.AddToRoleAsync(superAdminUser, "SuperAdmin");


                }









            }




            
            catch (Exception ex)
            {
                // Handele the exception

            }

        }





    }
}
