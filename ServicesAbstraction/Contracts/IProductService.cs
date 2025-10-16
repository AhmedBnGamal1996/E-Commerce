using Shared.Dtos;


namespace ServicesAbstraction.Contracts
{
    public interface IProductService
    {

        // Get All Products

        Task<IEnumerable<ProductResultDto>> GetAllProductsAsync();




        // Get All Brands
        Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync();



        // Get All Types

        Task<IEnumerable<TypeResultDto>> GetAllTypesAsync();



        // Get Product By Id


        Task<ProductResultDto> GetProductByIdAsync(int id);













    }





}
