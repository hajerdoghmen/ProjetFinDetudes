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
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public DateTime DateOfBirth { get; set; }
        public string Sex { get; set; }
    
    public User ToDomain( )
    {
        var result = new User();
        result.UserId = UserId;
        result.FirstName = FirstName;
        result.LastName = LastName;
        result.DateOfBirth =DateOfBirth;
        result.Sex = (Sex)Enum.Parse(typeof(Sex), Sex);
           return result;
    }
}
}


