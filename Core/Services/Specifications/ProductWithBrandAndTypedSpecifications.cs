using Domain.Entities.ProductModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductWithBrandAndTypedSpecifications : BaseSpecifications<Product, int>
    {


        public ProductWithBrandAndTypedSpecifications(int? typedId, int? brandId)

            : base(p => ( !typedId.HasValue || p.TypeId == typedId )
            && (!brandId.HasValue || p.BrandId == brandId) )


        {

            AddInclude(p => p.ProductBrand);

            AddInclude(p => p.ProductType);

        }

        public ProductWithBrandAndTypedSpecifications(int id )

           : base(p => p.Id == id)

        {

            AddInclude(p => p.ProductBrand);

            AddInclude(p => p.ProductType);

        }









    }


}
