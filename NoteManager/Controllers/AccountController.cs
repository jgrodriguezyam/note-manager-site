using System.Web.Mvc;
using NoteManager.Infrastructure.Attributes;

namespace NoteManager.Controllers
{
    public class AccountController : Controller
    {
        [HttpGet]
        [NoLogin]
        public ActionResult Login()
        {
            return View("Login");
        }
    }
}