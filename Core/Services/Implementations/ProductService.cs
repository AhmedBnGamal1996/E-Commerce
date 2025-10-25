using AutoMapper;
using Domain.Contracts;
using Domain.Entities.ProductModule;
using Services.Specifications;
using ServicesAbstraction.Contracts;
using Shared;
using Shared.Dtos;
using Shared.Shared;
using Shared.Shared.Enums;


namespace Services.Implementations
{
    public class ProductService(IUnitOfWork _unitOfWork , IMapper _mapper) : IProductService
    {




        public async Task<IEnumerable<BrandResultDto>> GetAllBrandsAsync()
        {

            // 1] Unit of Work ==> Generic Repo ==> GetAllBrands ==> IEnumerable<ProductBrand> 

            var brands =await  _unitOfWork.GetRepository<ProductBrand , int >().GetAllAsync();

            // 2] Mapping ==> IEnumerable<ProductBrand> ==> IEnumerable<BrandResultDto>

            var brandsResult = _mapper.Map<IEnumerable<BrandResultDto>>(brands);

            return brandsResult;



        }
         





        public async Task<PaginatedResult<ProductResultDto>> GetAllProductsAsync(ProductSpecificationParameters parameters)
        {



            var productRepo = _unitOfWork.GetRepository<Product, int>(); 


            var specification = new ProductWithBrandAndTypedSpecifications(parameters);

            
            var products = await productRepo.GetAllAsync(specification);
           
            
            var productsResult = _mapper.Map<IEnumerable<ProductResultDto>>(products);

           
            var pageSize = productsResult.Count();

            var countSpecifications = new ProductCountSpecifications(parameters);


            var totalCount = await productRepo.CountAsync(countSpecifications); 

          
            return new PaginatedResult<ProductResultDto>(parameters.PageIndex , pageSize , totalCount, productsResult);




        } 












        public async Task<IEnumerable<TypeResultDto>> GetAllTypesAsync()
        {
            var types = await _unitOfWork.GetRepository<ProductType, int>().GetAllAsync();
            var typesResult = _mapper.Map<IEnumerable<TypeResultDto>>(types);

            return typesResult;
        }









        public async Task<ProductResultDto> GetProductByIdAsync(int id)
        {
            var specification = new ProductWithBrandAndTypedSpecifications(id);
            var product = await _unitOfWork.GetRepository<Product, int>().GetByIdAsync(specification);

            var productResult = _mapper.Map<ProductResultDto>(product);

            return productResult;






        }








    }
}
