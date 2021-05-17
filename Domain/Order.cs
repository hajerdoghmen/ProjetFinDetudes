using System;
using System.Collections.Generic;
using System.Diagnostics.Contracts;
using System.Text;

namespace PFE.Domain
{
    public class Order
    {
        public Order()
        {

        }
        public  int OrderId { get; set; }
        public int UserId { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public Address ShippingAddress { get; set; }
        public Address BillingAddress { get; set; }
        public BankCard CreditCard { get; set; }
        public List <ArticleDetail> ArticleDetails { get; set; }
        public OrderType OrderType { get; set; }
        public ShippingMode ShippingMode { get; set; }
    }

    public enum OrderType
    {
        OneLine = 1,
        InStore = 2,
    }
    public enum ShippingMode
    {
        Standard = 1,
        Relay = 2,
        WithAppointment = 3,
    }
}
