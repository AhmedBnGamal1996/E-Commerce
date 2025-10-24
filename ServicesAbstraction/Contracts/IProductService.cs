using Shared.Dtos;
using Shared.Shared.Enums;


namespace ServicesAbstraction.Contracts
{
    public interface IProductService
    {

        // Get All Products

        Task<IEnumerable<ProductResultDto>> GetAllProductsAsync(int? typedId , int? brandId , ProductSortingOptions sort);




        // Get All Brands
        Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();



        // Get All Types

        Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();



        // Get Product By Id


        Task<ProductResultDto> GetProductByIdAsync(int id);













    }





}
