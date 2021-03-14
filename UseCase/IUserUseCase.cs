using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace PFE.UseCase
{
    public interface IUserUseCase
    {
        User GetUserById(int userId);
    }
}
