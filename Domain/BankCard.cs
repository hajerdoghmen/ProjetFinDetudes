using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Domain
{
   public  class BankCard
    {
        public int CreditCardId { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Name { get; set; }
        public int SecurityCode { get; set; }
        public string Mask()
        {
            return "xxxxxxxxx" + CardNumber.Substring(CardNumber.Length - 3, 3);
        }
    }
}
