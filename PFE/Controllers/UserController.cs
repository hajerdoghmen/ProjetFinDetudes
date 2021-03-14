using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PFE.Domain;
using PFE.UseCase;

namespace PFE
{
    [ApiController]
    [Route("api/[controller]")]
    public class UserController : Controller
    {
        private IUserUseCase _userUseCase;
        public UserController(IUserUseCase userUseCase)
        {
            _userUseCase = userUseCase;
        }
        [Route("GetUserById")]
        [HttpGet]

        public User GetUserById(int userId)
        {
            //var userUseCase = new UserUseCase();
            //var user = userUseCase.GetUserById(userId);

            User user = _userUseCase.GetUserById(userId);
            return user;
           
        }
    }
}


