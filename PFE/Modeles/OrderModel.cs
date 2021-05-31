using PFE.Domain;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Security.Permissions;
using System.Threading.Tasks;

namespace PFE.Modeles
{
    public class OrderModel
    {
        public OrderModel(Order o)
        {
            Id = o.OrderId;
            UserId = o.UserId;
            OrderDate = o.OrderDate;
            DeliveryDate = o.DeliveryDate;
            AdresseDeLivraison = o.ShippingAddress?.ToString();
            AdressDeFacturation = o.BillingAddress?.ToString();
            CreditCard = o.CreditCard.Mask();
            //CreditCard = Mask(o.CreditCard);
        }
        public int Id { get; set; }
        public int UserId { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }
        public string AdresseDeLivraison { get; set; }
        public string AdressDeFacturation { get; set; }
        public string CreditCard { get; set; }

        public string Mask(BankCard b)
        {
            return "xxxxxxxxx" + b.CardNumber.Substring(b.CardNumber.Length - 3, 3);
        }
    }

}








