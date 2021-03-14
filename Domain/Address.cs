using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace PFE.Domain
{
   public  class Address
    {
        public int Number { get; set; }
        public string Street { get; set; }
        public int ZIPcode { get; set; }
        public string City { get; set; }
        public Country Country { get; set; }
        public bool IsDefault { get; set; } //pour  choisir ue adresse par defaut
    }

    public enum Country
    {
        France,
        Belgium,
        Spain,
        Germany
    }

}
