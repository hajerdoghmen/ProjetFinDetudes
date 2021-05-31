using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using PFE.Domain;
using PFE.Modeles;
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

        public UsersModel GetUserById(int userId)
        {
            var userModel = new UsersModel(_userUseCase.GetUserById(userId));
            return userModel;
        }
        [Route("GetUserByIdMobile")]
        [HttpGet]
        public UserMobileModel GetUserByIdVersionMobile(int userId)
        {
            var userModelVersionMobile = new UserMobileModel(_userUseCase.GetUserById(userId, true));
            //GetUserById var userModelVersionMobile = new UserMobileModel(_userUseCase.GetUsersById(userId));
            return userModelVersionMobile;
        }
    }
}