using System.Web.Mvc;
using NoteManager.Infrastructure.Strings;
using NoteManager.Infrastructure.Enums;

namespace NoteManager.Infrastructure.Attributes.Extensions
{
    public static class ResultExecutingContextExtensions
    {
        public static string ActionName(this ResultExecutingContext filterContext)
        {
            return filterContext.RouteData.Values["action"].ToString();
        }

        public static string ControllerName(this ResultExecutingContext filterContext)
        {
            return filterContext.RouteData.Values["controller"].ToString();
        }

        public static object ContextModel(this ResultExecutingContext filterContext)
        {
            return filterContext.Controller.ViewData.Model;
        }

        public static bool ControllerIsEqualTo(this ResultExecutingContext filterContext, EController eControllerName)
        {
            return filterContext.ControllerName().IsEqualTo(eControllerName.ToString());
        }

        public static bool ActionIsEqualTo(this ResultExecutingContext filterContext, EAction eActionName)
        {
            return filterContext.ActionName().IsEqualTo(eActionName.ToString());
        }

        public static bool ControllerIsNotEqualTo(this ResultExecutingContext filterContext, EController eControllerName)
        {
            return !filterContext.ControllerIsEqualTo(eControllerName);
        }

        public static bool ActionIsNotEqualTo(this ResultExecutingContext filterContext, EAction eActionName)
        {
            return !filterContext.ActionIsEqualTo(eActionName);
        }
    }
}