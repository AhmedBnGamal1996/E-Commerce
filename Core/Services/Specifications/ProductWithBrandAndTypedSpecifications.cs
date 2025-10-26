using Domain.Entities.ProductModule;
using Shared.Shared;
using Shared.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductWithBrandAndTypedSpecifications : BaseSpecifications<Product, int>
    {


        public ProductWithBrandAndTypedSpecifications(ProductSpecificationParameters parameters)

            : base(p => ( !parameters.TypedId.HasValue || p.TypeId == parameters.TypedId)
            && (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId) 
            && ( string.IsNullOrEmpty(parameters.Search) 
            || p.Name.ToLower().Contains(parameters.Search.ToLower() )  )
            
            )


        {

            AddInclude(p => p.ProductBrand);  
             
            AddInclude(p => p.ProductType);


            switch(parameters.Sort)
            {
                case ProductSortingOptions.NameAsc:
                    AddOrderBy(p => p.Name);
                    break;
                case ProductSortingOptions.NameDesc:
                    AddOrderByDescending( p => p.Name);
                    break;
                case ProductSortingOptions.PriceAsc:
                    AddOrderBy( p => p.Price);
                    break;
                case ProductSortingOptions.PriceDesc:
                    AddOrderByDescending( p => p.Price);
                    break;
                default:
                    AddOrderBy( p => p.Name);
                    break;
            }



            ApplyPagination(parameters.PageSize, parameters.PageIndex); 


        }

        public ProductWithBrandAndTypedSpecifications(int id )

           : base(p => p.Id == id)

        {

            AddInclude(p => p.ProductBrand);

            AddInclude(p => p.ProductType);

        }









    }


}
