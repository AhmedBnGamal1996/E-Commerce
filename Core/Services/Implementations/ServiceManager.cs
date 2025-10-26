using AutoMapper;
using Domain.Contracts;
using ServicesAbstraction.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ServiceManager(IUnitOfWork _unitOfWork, IMapper _mapper , IBasketRepository _basketRepo) : IServiceManager

    {
        private readonly Lazy<IProductService> _productService = new Lazy<IProductService>(() => new ProductService(_unitOfWork , _mapper));
        public IProductService ProductService => _productService.Value;




        private readonly Lazy<IBasketService> _basketService = new Lazy<IBasketService>(() => new BasketService(_basketRepo, _mapper));

        public IBasketService BasketService => _basketService.Value;







    }
}
