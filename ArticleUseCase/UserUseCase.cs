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
            user.BillingAdress = addressRepository.GetBillingAdressByUserId(userId);
            user.ShippingAdress = addressRepository.GetShippingAdressByUserId(userId);

            //BankCardRepository bankCardRepository = new BankCardRepository();
            //List<BankCard> bankCards = bankCardRepository.GetBankCardByUserId(userId);
            //user.BankCard = bankCards;
            BankCardRepository bankCardRepository = new BankCardRepository();
            user.BankCard = bankCardRepository.GetBankCardByUserId(userId);

            return user;
        }
         
    }
}
