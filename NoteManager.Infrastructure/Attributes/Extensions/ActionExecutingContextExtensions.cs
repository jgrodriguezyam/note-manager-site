using System.Web.Mvc;
using NoteManager.Infrastructure.Strings;
using NoteManager.Infrastructure.Enums;

namespace NoteManager.Infrastructure.Attributes.Extensions
{
    public static class ActionExecutingContextExtensions
    {
        public static string ActionName(this ActionExecutingContext filterContext)
        {
            return filterContext.RouteData.Values["action"].ToString();
        }

        public static string ControllerName(this ActionExecutingContext filterContext)
        {
            return filterContext.RouteData.Values["controller"].ToString();
        }

        public static object ContextModel(this ActionExecutingContext filterContext)
        {
            return filterContext.ActionParameters["request"];
        }

        public static bool ActionIsEqualTo(this ActionExecutingContext filterContext, EAction eActionName)
        {
            return filterContext.ActionName().IsEqualTo(eActionName.ToString());
        }

        public static bool ControllerIsEqualTo(this ActionExecutingContext filterContext, EController eControllerName)
        {
            return filterContext.ControllerName().IsEqualTo(eControllerName.ToString());
        }

    }
}