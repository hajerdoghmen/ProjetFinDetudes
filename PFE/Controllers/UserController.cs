using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PFE.Domain;
using PFE.UseCase;

namespace ProjetFinEtudes
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        [Route("GetUserById")]
        [HttpGet]

        public User GetUserById(int userId)
        {
            var userUseCase = new UserUseCase();
            var user = userUseCase.GetUserById(userId);
            return user;
        }
    }
}


