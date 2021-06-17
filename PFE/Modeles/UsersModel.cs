using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Modeles
{
    public class UsersModel
    {
        public int UserId { get; set; }
        public Guid GuId { get; set; }
        public string FullName { get; set; }
        public List<string> ShippingAddress { get; set; }
        public List<string> BillingAddress { get; set; }
        public string DateOfBirth { get; set; }
        // Kol manesna3 objet userModel bech n3abih bi nafs el tari9a donc n3abih fi constructeur ye5ou paramétre 

        public UsersModel(User user)
        {
            UserId = user.UserId;
            GuId = user.GuiId;
            FullName = user.FirstName + " " + user.LastName;
            ShippingAddress = new List<string>(); //initialisaton de la liste net3ada men liste null el liste fergha
            foreach (var shippingAddress in user.ShippingAdress)
            {
                ShippingAddress.Add(shippingAddress.ToString());
            }
            //ShippingAddress = user.ShippingAdress.Select(shippingAdress => shippingAdress.ToString()).ToList();
            BillingAddress = user.BillingAdress.Select(billingAddress => billingAddress.ToString()).ToList();



            DateOfBirth = user.DateOfBirth.Year + "-" + user.DateOfBirth.Month + "-" + user.DateOfBirth.Day;
            DateOfBirth = user.DateOfBirth.ToString("yyyy-mm-dd");
        }
    }
}
