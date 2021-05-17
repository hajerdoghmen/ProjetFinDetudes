using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace PFE.Domain
{
   public  class Address
    {
        public int Id { get; set; }
        public int? Number { get; set; }
        public string Street { get; set; }
        public int? ZIPcode { get; set; }
        public string City { get; set; }
        public Country Country { get; set; }
        public bool? IsDefault { get; set; } //pour  choisir ue adresse par defaut
        public override string ToString()  // hedhi fct en principe te5ou paramétre de type Adress ama puisque fouma fard classe
                                       // donc testa3mlha direct men ghir ma7otha fel paramétres  w esta3mlhom direct 
        {
            return  Number.ToString() + " " + Street + " " + City + " " + ZIPcode.ToString();
        }
    }

    public enum Country
    {
        France,
        Belgium,
        Spain,
        Germany
    }
    


}
