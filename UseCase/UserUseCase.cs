
using PFE.Domain;
using PFE.Repository;
using Repository;
using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Runtime.Serialization;
using System.Text;


namespace PFE.UseCase
{
   public  class UserUseCase : IUserUseCase
    {

        private IAddressRepository _addressRepository;   // variable de classe de type interface 
        private IBankCardRepository _bankCardRepository;
        private IUserRepository _userRepository;
        
        public UserUseCase(IAddressRepository addressRepository
            , IBankCardRepository bankCardRepository,
            IUserRepository userRepository)
        {
            _addressRepository = addressRepository;
             _bankCardRepository = bankCardRepository;
            _userRepository = userRepository;
        }

        public User GetUserById(int userId)

        {
            //UserRepository userRepository = new UserRepository();
            //User user = userRepository.GetUsersById(userId);
            User user = _userRepository.GetUsersById(userId);


            //AddressRepository addressRepository = new AddressRepository();
            //user.BillingAdress = addressRepository.GetBillingAdressByUserId(userId);
            //user.ShippingAdress = addressRepository.GetShippingAdressByUserId(userId);

            user.BillingAdress = _addressRepository.GetBillingAdressByUserId(userId);
            user.ShippingAdress = _addressRepository.GetShippingAdressByUserId(userId);

            //BankCardRepository bankCardRepository = new BankCardRepository();
            //List<BankCard> bankCards = bankCardRepository.GetBankCardByUserId(userId);
            //user.BankCard = bankCards;
            //--------------- 3 lignes au dessus equibalent au deux lignes au dessous
            //BankCardRepository bankCardRepository = new BankCardRepository();
            //user.BankCard = bankCardRepository.GetBankCardByUserId(userId);

         
            user.BankCard = _bankCardRepository.GetBankCardByUserId(userId);



            return user;
        }

    }
}
