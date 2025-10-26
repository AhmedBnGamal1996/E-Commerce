

using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ServicesAbstraction.Contracts;
using Shared;
using Shared.Dtos.ProductModule;
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
        public async Task<ActionResult<PaginatedResult<ProductResultDto>>> GetAllProductsAsync([FromQuery]ProductSpecificationParameters parameters)
       => Ok ( await _serviceManager.ProductService.GetAllProductsAsync(parameters) ) ;


        // EndPoint ==> Get All Brands

        [HttpGet("Brands")]
        public async Task<ActionResult<IEnumerable<BrandResultDto>>> GetAllBrandsAsync()
       => Ok(await _serviceManager.ProductService.GetAllBrandsAsync());


        // EndPoint ==> Get All Types

        [HttpGet("Types")]
        public async Task<ActionResult<IEnumerable<TypeResultDto>>> GetAllTypesAsync()
       => Ok(await _serviceManager.ProductService.GetAllTypesAsync());



        [ProducesResponseType(typeof(ProductResultDto) , StatusCodes.Status200OK)]

        [ProducesResponseType(typeof(ProductResultDto), StatusCodes.Status404NotFound)]

        [ProducesResponseType(typeof(ProductResultDto), StatusCodes.Status500InternalServerError)]


        [ProducesResponseType(typeof(ProductResultDto), StatusCodes.Status400BadRequest)]





        // EndPoint ==> Get Product By ID

        [HttpGet("{id:int}")]
        public async Task<ActionResult<ProductResultDto>> GetProductByIdAsync(int id)
       => Ok(await _serviceManager.ProductService.GetProductByIdAsync(id));










    }



}
