using Shared.Dtos.OrderModule;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace Domain.Entities.OrderModule
{
    public record OrderRequest
    {

        public string BasketId { get; set; } = string.Empty;

        public AddressDto ShippingAddress { get; set; } 

        public int DeliveryMethodId { get; set; }













    }
}
