

using AutoMapper;
using Domain.Entities.ProductModule;
using Services.MappingProfiles;
using Shared.Dtos.ProductModule;

namespace Services.Mapping
{
    internal class ProductProfile : Profile
    {

        public ProductProfile()
        {

         CreateMap<ProductType, TypeResultDto>(); 
         CreateMap<ProductBrand, BrandResultDto>();
            CreateMap<Product, ProductResultDto>()
            .ForMember(dest => dest.BrandName, options => options.MapFrom(src => src.ProductBrand.Name))
            .ForMember(dest => dest.TypedName, options => options.MapFrom(src => src.ProductType.Name))
            .ForMember(dest => dest.PictureUrl, options => options.MapFrom<PictureUrlResolver>()  ); 






        }







    }







}
