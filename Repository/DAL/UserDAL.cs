using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Security.Principal;
using System.Text;

namespace PFE.Repository.DAL
{
    public class UserDAL
    {
        public int UserId { get; set; }
        public Guid GuidId { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }

        public User ToDomain()
        {
            return new User
            {
                UserId = UserId,
                GuiId =GuidId,
                FirstName = FirstName,
                LastName = LastName,
                DateOfBirth = DateOfBirth,
                Sex = (Sex)Enum.Parse(typeof(Sex), Sex)
            };

        }
    }
}


