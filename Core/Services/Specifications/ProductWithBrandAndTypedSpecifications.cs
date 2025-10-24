using Domain.Entities.ProductModule;
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


        public ProductWithBrandAndTypedSpecifications(int? typedId, int? brandId, ProductSortingOptions sort)

            : base(p => ( !typedId.HasValue || p.TypeId == typedId )
            && (!brandId.HasValue || p.BrandId == brandId) )


        {

            AddInclude(p => p.ProductBrand);

            AddInclude(p => p.ProductType);


            switch(sort)
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


        }

        public ProductWithBrandAndTypedSpecifications(int id )

           : base(p => p.Id == id)

        {

            AddInclude(p => p.ProductBrand);

            AddInclude(p => p.ProductType);

        }









    }


}
