using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository.DAL
{
   public  class CreditCardDAL
    {
        public int CreditCardId { get; set; }
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Name { get; set; }
        public int SecurityCode { get; set; }
        public BankCard ToDoamin()
        {
            var result = new BankCard();
            result.BankCaedId = CreditCardId;
            result.CardNumber = CardNumber;
            result.ExpirationDate = ExpirationDate;
            result.Name = Name;
            result.SecurityCode = SecurityCode;
            return result;
            
        }
    }
}
