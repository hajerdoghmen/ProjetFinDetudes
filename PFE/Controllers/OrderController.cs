using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using PFE.Domain;
using PFE.Modeles;
using PFE.UseCase;

namespace PFE
{
    [ApiController] 
    [Route("api/[controller]")]
    public class OrderController : Controller
    {
        private IOrderUseCase _orderUseCase;

        public OrderController(IOrderUseCase orderUseCase)
        {
            _orderUseCase = orderUseCase;
        }

        [Route("GetOrderById")] 
        [HttpGet]  

        public OrderModel GetOrderById(int orderId)
        {
            
            var orderModel = new OrderModel(_orderUseCase.GetOrderById(orderId));
            return orderModel;
            
           
           // return order;
        }
        //public OrderModel OrderModel (order)
        //{
        //    var order = _orderUseCase.GetOrderById(orderId);
        //    return order;
        //}
    }
}
