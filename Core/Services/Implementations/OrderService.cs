using AutoMapper;
using Domain.Contracts;
using Domain.Entities.BasketModule;
using Domain.Entities.OrderModule;
using Domain.Entities.ProductModule;
using Domain.Exceptions;
using Services.Specifications;
using ServicesAbstraction.Contracts;
using Shared.Dtos.OrderModule;
using System.Diagnostics;
using ShippingAddress = Domain.Entities.OrderModule.Address;

namespace Services.Implementations
{
    public class OrderService(IMapper mapper , IBasketRepository basketRepository , IUnitOfWork unitOfWork) : IOrderService
    {
        public async Task<OrderResult> CreateOrdersAsync(OrderRequest request, string userEmail)
        {



            var shippgingAddress = mapper.Map<ShippingAddress>(request.ShippingAddress);

            var basket = await basketRepository.GetBasketAsync(request.BasketId) ?? throw new BasketNotFoundException(request.BasketId); 
            
            var orderItems = new List<OrderItem>();

            foreach(var item in basket.BasketItems)
            {
        
                var product = await unitOfWork.GetRepository<Product , int>().GetByIdAsync(item.Id) 
                    ?? throw new ProductNotFoundException(item.Id);

                orderItems.Add(CreateOrderItem(item, product)); 


            }

            var deliveryMethod = await unitOfWork.GetRepository<DeliveryMethod , int>().GetByIdAsync(request.DeliveryMethodId) 
                ?? throw new DeliveryMethodNotFoundException(request.DeliveryMethodId);



            var subTotal = orderItems.Sum(item => item.Price * item.Quantity);

            var order = new Order(userEmail,shippgingAddress,orderItems , deliveryMethod , subTotal);


            await unitOfWork.GetRepository<Order , Guid>().AddAsync(order);

            await unitOfWork.SaveChangeAsync();

            return  mapper.Map<OrderResult>(order);









        }


        private OrderItem CreateOrderItem(BasketItem item, Product product)
        {


            var productInOrderItem = new ProductInOrderItem(
                product.Id,
                product.Name,
                product.PictureUrl);
            return new OrderItem(
                productInOrderItem,
                product.Price,
                item.Quantity);



        }








         public async Task<IEnumerable<DeliveryMethodResult>> GetDeliveryMethodsAsync()
         {

            var deliveryMethods =  await unitOfWork.GetRepository<DeliveryMethod , int>().GetAllAsync();

            return mapper.Map<IEnumerable<DeliveryMethodResult>>(deliveryMethods);



        }









         public async Task<OrderResult> GetOrderByIdAsync(Guid id)
         {

            var order = await unitOfWork.GetRepository<Order , Guid>()
                .GetByIdAsync(new OrderWithIncludesSpecifications(id)) 
                ?? throw new OrderNotFoundException(id);
                


            return mapper.Map<OrderResult>(order);


        }






        public async Task<IEnumerable<OrderResult>> GetOrdersByEmailAsync(string userEmail)
         {

            var orders = await unitOfWork.GetRepository<Order , Guid>()
                .GetAllAsync(new OrderWithIncludesSpecifications(userEmail));


            return mapper.Map<IEnumerable<OrderResult>>(orders);





        }



         



    }
}
