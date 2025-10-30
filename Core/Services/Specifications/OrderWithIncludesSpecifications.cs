using Domain.Entities.OrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Services.Specifications
{
    internal class OrderWithIncludesSpecifications : BaseSpecifications<Order , Guid>
    {

        public OrderWithIncludesSpecifications(Guid id ) :base(o => o.Id == id)
        {
            AddInclude(o => o.DeliveryMethod); 
            AddInclude(o => o.OrderItems);

        }

        public OrderWithIncludesSpecifications(string userEmail) : base(o => o.UserEmail == userEmail)
        {
            AddInclude(o => o.DeliveryMethod);
            AddInclude(o => o.OrderItems);
            AddInclude(o => o.UserEmail);
            
        }











    }
}
