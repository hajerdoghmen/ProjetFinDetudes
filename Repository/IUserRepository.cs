﻿using PFE.Domain;
using System;
using System.Collections.Generic;
using System.Text;

namespace Repository
{
    public interface IUserRepository
    {
        User GetUsersById(int userId);
    }
}
