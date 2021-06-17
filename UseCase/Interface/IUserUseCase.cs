using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.UseCase
{
    public interface IUserUseCase
    {
        User GetUser(int? userId, Guid? guidId, bool isMobile = false);
        //User GetUsersById(int userId);
    }
}
