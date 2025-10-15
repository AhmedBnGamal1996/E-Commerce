


using Domain.Entities.ProductModule;
using System.Text.Json;

namespace Presistence.Data
{
    public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding

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

               await  _dbContext.SaveChangesAsync();


            }


            catch (Exception ex)
            {
                // Handele the exception

            }








        }




    }
}
