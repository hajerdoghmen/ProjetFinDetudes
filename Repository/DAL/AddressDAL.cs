using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Runtime.CompilerServices;
using System.Text;

namespace PFE.Repository.DAL
{
   public  class AddressDAL
    {
		public int Number { get; set; }
		public string Street { get; set; }
		public int ZipCode { get; set; }
		public string  City { get; set; }
		public string  Country { get; set; }
		public bool IsDefault { get; set; }

		public Address ToDomain ()
		{
			var result = new Address
			{
				Number = Number,
				Street = Street,
				ZIPcode = ZipCode,
				City = City,
				Country = (Country)Enum.Parse(typeof(Country), Country),
				IsDefault = IsDefault
			};
			return result;
		}
		 
	}
}
