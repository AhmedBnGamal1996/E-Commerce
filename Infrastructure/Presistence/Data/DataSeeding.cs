


using Domain.Entities.ProductModule;
using System.Text.Json;

namespace Presistence.Data
{
    public class DataSeeding(StoreDbContext _dbContext) : IDataSeeding

    {
        public void SeedData()
        {

            // Check Any pending migrations ==> Apply Migrations

            try
            {

                if (_dbContext.Database.GetPendingMigrations().Any())

                {


                    _dbContext.Database.Migrate();


                }



                if (!_dbContext.ProductBrands.Any())

                {

                    var productBrandData = File.ReadAllText("..\\Infrastructure\\Presistence\\Data\\DataSeed\\brands.json");

                    // Json To C# Object

                    var productBrands = JsonSerializer.Deserialize<List<ProductBrand>>(productBrandData);

                    if (productBrands != null && productBrands.Any())
                    {
                        _dbContext.ProductBrands.AddRange(productBrands);
                    }

                }



                if (!_dbContext.ProductTypes.Any())

                {

                    var productTypeData = File.ReadAllText("..\\Infrastructure\\Presistence\\Data\\DataSeed\\types.json");

                    // Json To C# Object

                    var productTypes = JsonSerializer.Deserialize<List<ProductType>>(productTypeData);

                    if (productTypes != null && productTypes.Any())
                    {
                        _dbContext.ProductTypes.AddRange(productTypes);
                    }

                }



                if (!_dbContext.Products.Any())

                {

                    var productData = File.ReadAllText("..\\Infrastructure\\Presistence\\Data\\DataSeed\\products.json");

                    // Json To C# Object

                    var products = JsonSerializer.Deserialize<List<Product>>(productData);

                    if (products != null && products.Any())
                    {
                        _dbContext.Products.AddRange(products);
                    }


                }

                _dbContext.SaveChanges();


            }


            catch (Exception ex)
            {
                // Handele the exception

            }








        }




    }
}
