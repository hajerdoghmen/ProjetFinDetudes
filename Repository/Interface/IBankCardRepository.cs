using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
   public  interface IBankCardRepository
    {
        List<BankCard> GetBankCardByUserId(int userId);
    }
}
