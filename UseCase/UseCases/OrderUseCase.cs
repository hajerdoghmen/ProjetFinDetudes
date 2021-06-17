using PFE.Domain;
using PFE.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.UseCase
{
    public class OrderUseCase: IOrderUseCase
    {
        private IOrderRepository _orderRepository;


        public OrderUseCase(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }
        public Order GetOrderById(int orderId)
        {
            if (orderId < 1)
            {
                throw new Exception("orderId inrouvable");
            }
            Order order = _orderRepository.GetOrderById(orderId);
           
            return order;
        }
    }
}
