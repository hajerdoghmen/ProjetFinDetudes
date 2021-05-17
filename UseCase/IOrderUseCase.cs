using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.UseCase
{
    public interface IOrderUseCase
    {
        Order GetOrderById(int orderId);
    }
}