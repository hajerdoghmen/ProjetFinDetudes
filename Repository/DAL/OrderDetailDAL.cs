using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Security.Principal;
using System.Text;

namespace PFE.Repository.DAL
{
    public class OrderDetailDAL
    {
        public int OrderId { get; set; }
        public double Price { get; set; }
        public DateTime OrderDate { get; set; }
        public DateTime DeliveryDate { get; set; }

        public int UserId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }

        public int? BillingAdressId { get; set; }
        public string Bi_Country{ get; set;}
        public string Bi_City { get; set; }
        public int? Bi_Number { get; set; }
        public string Bi_Street { get; set; }
        public int? Bi_ZipCode { get; set; }
        public bool? Bi_IsDefault { get; set; }

        public int? ShippingAdressId { get; set; }
        public string Sh_Country { get; set; }
        public string Sh_City { get; set; }
        public int? Sh_Number { get; set; }
        public string Sh_Street { get; set; }
        public int? Sh_ZipCode { get; set; }
        public bool? Sh_IsDefault { get; set; }

        public int? CreditCardId { get; set; }
        public string CreditCardNumbr { get; set; }
        public DateTime ExpirtionDate { get; set; }
        public string Label { get; set; }
        public int SecurityCode { get; set; }

        public int ShippingModeId { get; set; }
        public string ShippingMode { get; set; }

        public int OrderTypeId { get; set; }
        public string OrderType { get; set; }
        
        public int ArticleId { get; set; }
        public int Amount { get; set; }
       
       

        public static Order ToDomain(List<OrderDetailDAL> orderDetails)
        {
            var firstOrderDetail = orderDetails.FirstOrDefault(); // Mafhemtouch
            if (firstOrderDetail == null) // liste vide
            {
                return null;
            }

            var result = new Order();
            result.OrderId = firstOrderDetail.OrderId; //result. mta3 classe order n7ot fiha  var eli sna3tha . OrderId ta3 class Dall
            result.Price = firstOrderDetail.Price;
            result.OrderDate = firstOrderDetail.OrderDate;
            result.DeliveryDate = firstOrderDetail.DeliveryDate;
            //  result.ShippingMode = (ShippingMode)Enum.Parse(typeof (ShippingMode),firstOrderDetail.ShippingMode); hedhi mel string lel enum
            result.ShippingMode = (ShippingMode)firstOrderDetail.ShippingModeId;
            result.OrderType = (OrderType)firstOrderDetail.OrderTypeId; 

            if (firstOrderDetail.ShippingAdressId.HasValue)
            {
                result.ShippingAddress = new Address()
                {
                    Id = firstOrderDetail.ShippingAdressId.Value,
                    Number = firstOrderDetail.Sh_Number,
                    Country = (Country)Enum.Parse(typeof(Country), firstOrderDetail.Sh_Country),//
                    Street = firstOrderDetail.Sh_Street,
                    ZIPcode = firstOrderDetail.Sh_ZipCode,
                    City = firstOrderDetail.Sh_City,
                    IsDefault = firstOrderDetail.Sh_IsDefault,
                };
            }
            
            if (firstOrderDetail.BillingAdressId.HasValue)
            {
                result.BillingAddress = new Address()
                {
                    Id = firstOrderDetail.ShippingAdressId.Value,
                    Number = firstOrderDetail.Bi_Number,
                    Country = (Country)Enum.Parse(typeof(Country), firstOrderDetail.Bi_Country),
                    Street = firstOrderDetail.Bi_Street,
                    ZIPcode = firstOrderDetail.Bi_ZipCode,
                    City = firstOrderDetail.Bi_City,
                    IsDefault = firstOrderDetail.Bi_IsDefault,

                };
            }
            if (firstOrderDetail.CreditCardId.HasValue)
            {
                result.CreditCard = new BankCard()
                {
                    CreditCardId = firstOrderDetail.CreditCardId.Value,
                    CardNumber = firstOrderDetail.CreditCardNumbr,
                    ExpirationDate = firstOrderDetail.ExpirtionDate,
                    Name = firstOrderDetail.Label,
                    SecurityCode = firstOrderDetail.SecurityCode,
                };
            }
            result.ArticleDetails = new List<ArticleDetail>();

            foreach (OrderDetailDAL orderDetailDAL in orderDetails)
            {
                result.ArticleDetails.Add(new ArticleDetail()
                {
                    ArticleId = orderDetailDAL.ArticleId,
                    Quantity = orderDetailDAL.Amount
                });
            }

            //linq
            //var cher = orderDetails.Where(od => od.Price > 10).ToList();
            //var cc = orderDetails.Select(od => new ArticleDetail() { ArticleId = od.ArticleId, Quantity = od.Amount }).ToList();

            return result;
        }

    }
}

//for eq foreach,, nbr iteration connu
//while min exec 0, nbr iteration inconnu
//do while min exec 1, nbr iteration inconnu



//int x1 = 5;
//int? x2 = null;
//int somme = 0;
//if (x2.HasValue)
//{
//    somme = x1 + x2.Value;
//}
//else
//{
//    somme = x1 + 0;
//}
//int somme2 = x2.HasValue ? x2.Value + x1 : x1;
//esta3malet ? : nullable type and ternary operation
