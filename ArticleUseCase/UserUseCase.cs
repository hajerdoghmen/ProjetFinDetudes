using ProjetFinDetudes.Model;
using ProjetFinDetudes.Repository;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Text;


namespace ProjetFinEtudes.UseCase
{
   public  class UserUseCase
    {
        public User GetUserById(int userId)

        {
            UserRepository userRepository = new UserRepository();
            User user = userRepository.GetUsersById(userId);

            AddressRepository addressRepository = new AddressRepository();
            List<Address> billingAdress = addressRepository.GetBillingAdressByUserId(userId);
            user.BillingAdress = billingAdress;


            AddressRepository addressRepository2 = new AddressRepository();
            List<Address> shippingAdress = addressRepository2.GetShippingAdressByUserId(userId);
            user.ShippingAdress = shippingAdress;


            BankCardRepository bankCardRepository = new BankCardRepository();
            List<BankCard> bankCards = bankCardRepository.GetBankCardByUserId(userId);
            user.BankCard = bankCards;


            return user;
        }
         
    }
}
