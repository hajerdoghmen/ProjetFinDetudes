using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace  PFE.Repository
{
   public  interface IOrderRepository
    {
        Order GetOrderById(int OrderId);
    }
}
