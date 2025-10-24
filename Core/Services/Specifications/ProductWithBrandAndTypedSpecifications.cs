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


        public ProductWithBrandAndTypedSpecifications()

            : base(null)

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
