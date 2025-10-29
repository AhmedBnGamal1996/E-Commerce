using Domain.Entities.OrderModule;
using Shared.Dtos.OrderModule;


namespace ServicesAbstraction.Contracts
{
    public  interface IOrderService
    {

        // GetByID ==> Take Guid Id ==> Return OrderResult 

        Task<OrderResult> GetOrderByIdAsync(Guid id);



        // GetAllByEmail ==> Take String Email ===> Return Enumerable<OrderResult> 

        Task<IEnumerable<OrderResult>> GetOrdersByEmailAsync(string userEmail);



        // CreateOrder ==> Take OrderRequest , String Email  => Return OrderResult 

        Task<OrderResult> CreateOrdersAsync(OrderRequest order , string userEmail);


        /// GetDeliveryMethods ==> Return Enumerable<DeliveryMethodsResult> 

        Task<IEnumerable<DeliveryMethodResult>> GetDeliveryMethodsAsync();






    }
}
