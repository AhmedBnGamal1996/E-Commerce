using Domain.Entities.ProductModule;
using Shared.Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class ProductCountSpecifications : BaseSpecifications<Product , int >
    {

        public ProductCountSpecifications(ProductSpecificationParameters parameters) 
            
            : base(p => (!parameters.TypedId.HasValue || p.TypeId == parameters.TypedId)

            && (!parameters.BrandId.HasValue || p.BrandId == parameters.BrandId)

            && (string.IsNullOrEmpty(parameters.Search)

            || p.Name.ToLower().Contains(parameters.Search.ToLower() )))

        {










        }


        






    }
}
