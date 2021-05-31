using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace PFE.Modeles
{
    public class UserMobileModel
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string DateOfBirth { get; set; }
        public UserMobileModel(User user)
        {
            FirstName = user.FirstName;
            LastName = user.LastName;
            DateOfBirth = user.DateOfBirth.ToString("yyyy-mm-dd");
        }
    }

}
