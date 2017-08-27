using System;
using System.Net;
using System.Web.Mvc;
using System.Web.Routing;
using NoteManager.Infrastructure.Attributes.Extensions;
using NoteManager.Infrastructure.Enums;
using NoteManager.Infrastructure.JsonResults;
using NoteManager.Infrastructure.TempDatas;

namespace NoteManager.Infrastructure.Attributes
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true)]
    public class ExceptionAttribute : HandleErrorAttribute
    {
        public override void OnException(ExceptionContext filterContext)
        {
            var typeException = filterContext.TypeException();
            var messageException = filterContext.MessageException();
            var controllerException = filterContext.ControllerBase();
            filterContext.ExceptionHandled = true;
            filterContext.HttpContext.Response.TrySkipIisCustomErrors = true;
            filterContext.HttpContext.Response.StatusCode = (int) HttpStatusCode.OK;

            if (filterContext.IsAjaxRequest())
            {
                filterContext.Result = new JsonFactory().Failure(typeException, messageException);
            }
            else
            {
                SetResult(filterContext);
                new TempDataFactory().CreateFailure(controllerException, messageException);
            }
        }

        public void SetResult(ExceptionContext filterContext)
        {
            if (filterContext.ActionIsEqualsThan(EAction.New))
            {
                var routeValue = new RouteValueDictionary(new { controller = filterContext.ControllerName(), action = EAction.Index });
                filterContext.Result = new RedirectToRouteResult(routeValue);
            }

            if (filterContext.ActionIsEqualsThan(EAction.Edit))
            {
                var routeValue = new RouteValueDictionary(new { controller = filterContext.ControllerName(), action = EAction.Index });
                filterContext.Result = new RedirectToRouteResult(routeValue);
            }
        }
    }
}