using System.Web.Mvc;
using NoteManager.Infrastructure.Attributes;

namespace NoteManager.Controllers
{
    [Authenticate]
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }
    }
}