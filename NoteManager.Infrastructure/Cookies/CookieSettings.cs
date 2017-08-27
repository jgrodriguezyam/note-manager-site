using System;
using System.Web;
using System.Web.Mvc;
using System.Web.Security;
using NoteManager.Infrastructure.Objects;
using NoteManager.Infrastructure.Strings;

namespace NoteManager.Infrastructure.Cookies
{
    public static class CookieSettings
    {
        public static void CreateCookie(this Controller controller, string userName, string password, int id, bool rememberMe)
        {
            var timeout = rememberMe ? CookieConstants.TimeToCookiePerOneYear : CookieConstants.TimeToCookieExpired;

            var ticketUserName = new FormsAuthenticationTicket(userName, rememberMe, timeout);
            var ticketPass = new FormsAuthenticationTicket(password, rememberMe, timeout);
            var ticketId = new FormsAuthenticationTicket(id.ToString(), rememberMe, timeout);

            var encryptedUserName = FormsAuthentication.Encrypt(ticketUserName);
            var encryptedPass = FormsAuthentication.Encrypt(ticketPass);
            var encryptedId = FormsAuthentication.Encrypt(ticketId);

            var cookieUserName = new HttpCookie(CookieConstants.CookieUserName, encryptedUserName);
            var cookiePass = new HttpCookie(CookieConstants.CookiePass, encryptedPass);
            var cookieId = new HttpCookie(CookieConstants.CookieId, encryptedId);

            cookieUserName.Expires = DateTime.Now.AddMinutes(timeout);
            cookiePass.Expires = DateTime.Now.AddMinutes(timeout);
            cookieId.Expires = DateTime.Now.AddMinutes(timeout);

            cookieUserName.HttpOnly = true;
            cookiePass.HttpOnly = true;
            cookieId.HttpOnly = true;

            controller.Response.Cookies.Add(cookieUserName);
            controller.Response.Cookies.Add(cookiePass);
            controller.Response.Cookies.Add(cookieId);

            AddUserToSession(userName);
        }

        public static void RemoveCookies(this Controller controller)
        {
            var cookieUserName = controller.Request.Cookies[CookieConstants.CookieUserName];
            var cookiePass = controller.Request.Cookies[CookieConstants.CookiePass];
            var cookieId = controller.Request.Cookies[CookieConstants.CookieId];

            cookieUserName.Expires = DateTime.Now.AddMinutes(CookieConstants.TimeToCookieExpired);
            cookiePass.Expires = DateTime.Now.AddMinutes(CookieConstants.TimeToCookieExpired);
            cookieId.Expires = DateTime.Now.AddMinutes(CookieConstants.TimeToCookieExpired);

            controller.Response.Cookies.Add(cookieUserName);
            controller.Response.Cookies.Add(cookiePass);
            controller.Response.Cookies.Add(cookieId);

            DestroyUserSession();
        }

        public static string RetrieveCookieUserName(this Controller controller)
        {
            var cookie = controller.Request.Cookies[CookieConstants.CookieUserName];
            try
            {
                if(cookie.IsNotNull())
                    return FormsAuthentication.Decrypt(cookie.Value).Name;
            }
            catch (Exception)
            {
                if (cookie.IsNotNull())
                    RemoveCookies(controller);
            }
            return string.Empty;
        }

        public static string RetrieveCookiePassword(this Controller controller)
        {
            var cookie = controller.Request.Cookies[CookieConstants.CookiePass];
            try
            {
                if (cookie.IsNotNull())
                    return FormsAuthentication.Decrypt(cookie.Value).Name;
            }
            catch (Exception)
            {
                if (cookie.IsNotNull())
                    RemoveCookies(controller);
            }
            return string.Empty;
        }

        public static string RetrieveCookieId(this Controller controller)
        {
            var cookie = controller.Request.Cookies[CookieConstants.CookieId];
            try
            {
                if (cookie.IsNotNull())
                    return FormsAuthentication.Decrypt(cookie.Value).Name;
            }
            catch (Exception)
            {
                if (cookie.IsNotNull())
                    RemoveCookies(controller);
            }
            return string.Empty;
        }

        public static bool ExistsCookieUserName(this Controller controller)
        {
            return controller.RetrieveCookieUserName().IsNotNullOrEmpty();
        }

        public static bool ExistsCookiePassword(this Controller controller)
        {
            return controller.RetrieveCookiePassword().IsNotNullOrEmpty();
        }

        public static bool ExistsCookieId(this Controller controller)
        {
            return RetrieveCookieId(controller).IsNotNullOrEmpty();
        }

        public static void AddUserToSession(string id)
        {
            FormsAuthentication.SetAuthCookie(id, true);
        }

        public static bool ExistUserInSession()
        {
            return HttpContext.Current.User.Identity.IsAuthenticated;
        }

        public static void DestroyUserSession()
        {
            FormsAuthentication.SignOut();
        }
    }
}