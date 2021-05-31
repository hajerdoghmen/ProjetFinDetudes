using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IAddressRepository
    {
        List<Address> GetBillingAdressByUserId(int userId);
        List<Address> GetShippingAdressByUserId(int userId);

    }
}
