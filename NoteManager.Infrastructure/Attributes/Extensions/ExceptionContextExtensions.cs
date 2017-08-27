using System;
using System.Linq;
using System.Web.Mvc;
using NoteManager.Infrastructure.Strings;
using NoteManager.Infrastructure.Enums;

namespace NoteManager.Infrastructure.Attributes.Extensions
{
    public static class ExceptionContextExtensions
    {
        public static string ActionName(this ExceptionContext filterContext)
        {
            return filterContext.RouteData.Values["action"].ToString();
        }

        public static string ControllerName(this ExceptionContext filterContext)
        {
            return filterContext.RouteData.Values["controller"].ToString();
        }

        public static int IdToRequest(this ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.UrlReferrer.Segments.LastOrDefault().ConvertToint();
        }

        public static bool ControllerIsEqualsThan(this ExceptionContext filterContext, EController eControllerName)
        {
            return filterContext.ControllerName().IsEqualTo(eControllerName.ToString());
        }

        public static bool ActionIsEqualsThan(this ExceptionContext filterContext, EAction eActionName)
        {
            return filterContext.ActionName().IsEqualTo(eActionName.ToString());
        }

        public static bool ControllerIsNotEqualsThan(this ExceptionContext filterContext, EController eControllerName)
        {
            return !filterContext.ControllerIsEqualsThan(eControllerName);
        }

        public static string MessageException(this ExceptionContext filterContext)
        {
            //return filterContext.Exception.Message + " " + filterContext.Exception.StackTrace;
            return filterContext.Exception.Message;
        }

        public static Type TypeException(this ExceptionContext filterContext)
        {
            return filterContext.Exception.GetType();
        }

        public static bool IsAjaxRequest(this ExceptionContext filterContext)
        {
            return filterContext.HttpContext.Request.IsAjaxRequest();
        }

        public static ControllerBase ControllerBase(this ExceptionContext filterContext)
        {
            return filterContext.Controller;
        }
    }
}