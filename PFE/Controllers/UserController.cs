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

        public UsersModel GetUserById (int userId)
        {
            var userModel = new UsersModel(_userUseCase.GetUser(userId: userId, guidId: null));
            return userModel;
        }

        [Route("GetUserByRef")]
        [HttpGet]

        public UsersModel GetUserByRef(Guid userRef)
        {
            var userModel = new UsersModel(_userUseCase.GetUser(null, userRef));
            return userModel;
        }

        [Route("GetUserByIdMobile")]
        [HttpGet]
        public UserMobileModel GetUserByIdVersionMobile(int userId, Guid guidId)
        {
            var userModelVersionMobile = new UserMobileModel(_userUseCase.GetUser(userId, guidId, true));
            //GetUserById var userModelVersionMobile = new UserMobileModel(_userUseCase.GetUsersById(userId));
            return userModelVersionMobile;
        }
    }
}