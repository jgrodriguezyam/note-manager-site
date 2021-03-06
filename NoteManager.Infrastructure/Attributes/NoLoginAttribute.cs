using System.Web.Mvc;
using System.Web.Routing;
using NoteManager.Infrastructure.Cookies;
using NoteManager.Infrastructure.Enums;

namespace NoteManager.Infrastructure.Attributes
{
    public class NoLoginAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            base.OnActionExecuting(filterContext);
            if (CookieSettings.ExistUserInSession())
            {
                filterContext.Result = new RedirectToRouteResult(new RouteValueDictionary(new
                {
                    controller = EController.Home,
                    action = EAction.Index
                }));
            }
        }
    }
}