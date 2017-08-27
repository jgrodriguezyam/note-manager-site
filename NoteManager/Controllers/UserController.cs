using System;
using System.Web.Mvc;
using FastMapper;
using NoteManager.DTO.Users;
using NoteManager.Infrastructure.Attributes;
using NoteManager.Infrastructure.Cookies;
using NoteManager.Infrastructure.Enums;
using NoteManager.Infrastructure.TempDatas;
using NoteManager.Models.Users;
using NoteManager.Services.Interfaces;

namespace NoteManager.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserService _userService;

        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        [AllowAnonymous]
        public ActionResult Login(LoginUser loginUser)
        {
            try
            {
                var loginUserRequest = TypeAdapter.Adapt<LoginUser, LoginUserRequest>(loginUser);
                var userResponse = _userService.Login(loginUserRequest);
                this.CreateCookie(loginUser.UserName, loginUser.Password, userResponse.UserId, true);
                return RedirectToAction(EAction.Index.ToString(), EController.Home.ToString());
            }
            catch (Exception exception)
            {
                new TempDataFactory().CreateFailure(this, exception.Message);
                return RedirectToAction(EAction.Login.ToString(), EController.Account.ToString());
            }
        }

        [HttpGet]
        [AllowAnonymous]
        public ActionResult Logout()
        {
            this.RemoveCookies();
            return RedirectToAction(EAction.Login.ToString(), EController.Account.ToString());
        }
    }
}