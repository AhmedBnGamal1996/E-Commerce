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

        public string BasketId { get; init; } = string.Empty;

        public AddressDto ShippingAddress { get; init; } 

        public int DeliveryMethodId { get; init; }













    }
}
