

using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction.Contracts;
using Shared.Dtos;
using Shared.Shared;
using Shared.Shared.Enums;

namespace Presentation.Controllers
{

    [ApiController]
    [Route("api/[controller]")]     // BaseUrl/api/WeatherForecast

    public class ProductsController(IServiceManager _serviceManager) : ControllerBase 
    {

        // EndPoint ==> Get All Products
         

        [HttpGet]
        public async Task<ActionResult<IEnumerable<ProductResultDto>>> GetAllProductsAsync([FromQuery]ProductSpecificationParameters parameters)
       => Ok ( await _serviceManager.ProductService.GetAllProductsAsync(parameters) ) ;


        // EndPoint ==> Get All Brands

        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAllBrandsAsync()
       => Ok(await _serviceManager.ProductService.GetAllBrandsAsync());


        // EndPoint ==> Get All Types

        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypesAsync()
       => Ok(await _serviceManager.ProductService.GetAllTypesAsync());


        // EndPoint ==> Get Product By ID

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResultDto>> GetProductByIdAsync(int id)
       => Ok(await _serviceManager.ProductService.GetProductByIdAsync(id));










    }



}
