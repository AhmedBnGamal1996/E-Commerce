using AutoMapper;
using Domain.Contracts;
using Domain.Entities.IdentityModule;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using ServicesAbstraction.Contracts;
using Shared.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Implementations
{
    public class ServiceManager
        (IUnitOfWork _unitOfWork, IMapper _mapper ,IBasketRepository _basketRepo ,
        
        UserManager<User> _userManager , IOptions<JwtOptions> _Options) 

        : IServiceManager



    {
        private readonly Lazy<IProductService> _productService = new Lazy<IProductService>(() => new ProductService(_unitOfWork , _mapper));
        public IProductService ProductService => _productService.Value;




        private readonly Lazy<IBasketService> _basketService = new Lazy<IBasketService>(() => new BasketService(_basketRepo, _mapper));

        public IBasketService BasketService => _basketService.Value;

        private readonly Lazy<IAuthenticationService> _authService = new Lazy<IAuthenticationService>(() => new AuthenticationService(_userManager , _Options)); 

        public IAuthenticationService AuthenticationService => _authService.Value;
    }
}
