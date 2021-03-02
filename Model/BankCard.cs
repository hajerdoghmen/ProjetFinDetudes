using System;
using System.Collections.Generic;
using System.Text;

namespace ProjetFinDetudes.Model
{
   public  class BankCard
    {
        public string CardNumber { get; set; }
        public DateTime ExpirationDate { get; set; }
        public string Name { get; set; }
        public int SecurityCode { get; set; }

    }
}
