using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.Domain
{
    public class User
    {
        public int UserId { get; set; }
        public Guid GuiId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public  DateTime DateOfBirth { get; set; }
        public Sex Sex { get; set; }
         
        public List<Address> BillingAdress { get; set; }
        public List<Address> ShippingAdress { get; set; }
        public List<BankCard> BankCard { get; set; }

    }
    public enum Sex
    {
        Mr,
        Mrs
    }
}
