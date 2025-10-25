using Shared.Shared.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.Shared
{
    public class ProductSpecificationParameters
    {

        private const int defaultPageSize = 5;
        private const int MaxPageSize = 10 ;


        public int? TypedId { get; set; }

        public  int? BrandId { get; set; }

        public ProductSortingOptions Sort { get; set; }

        public string? Search {  get; set; }

        public int PageIndex { get; set; }


        private int _pageSize = defaultPageSize; 


        public int PageSize
        {
            get { return _pageSize; }
            set { _pageSize = value > MaxPageSize ? MaxPageSize : value  ; }
        }






    }
}
