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
        public static void CreateCookie(this Controller controller, string email, string password, bool rememberMe)
        {
            var timeout = rememberMe ? CookieConstants.TimeToCookiePerOneYear : CookieConstants.TimeToCookieExpired;

            var ticketEmail = new FormsAuthenticationTicket(email, rememberMe, timeout);
            var ticketPass = new FormsAuthenticationTicket(password, rememberMe, timeout);

            var encryptedEmail = FormsAuthentication.Encrypt(ticketEmail);
            var encryptedPass = FormsAuthentication.Encrypt(ticketPass);

            var cookieEmail = new HttpCookie(CookieConstants.CookieEmail, encryptedEmail);
            var cookiePass = new HttpCookie(CookieConstants.CookiePass, encryptedPass);

            cookieEmail.Expires = DateTime.Now.AddMinutes(timeout);
            cookiePass.Expires = DateTime.Now.AddMinutes(timeout);

            cookieEmail.HttpOnly = true;
            cookiePass.HttpOnly = true;

            controller.Response.Cookies.Add(cookieEmail);
            controller.Response.Cookies.Add(cookiePass);
        }

        public static void ChangeLenguage(this Controller controller, string languageAbbrevation)
        {
            var cookieLanguageAbbrevation = new HttpCookie(CookieConstants.CookieLenguage, languageAbbrevation);
            cookieLanguageAbbrevation.Expires = DateTime.Now.AddMinutes(CookieConstants.TimeToCookiePerOneYear);
            cookieLanguageAbbrevation.HttpOnly = true;
            controller.Response.Cookies.Add(cookieLanguageAbbrevation);
        }

        public static void RemoveCookie(this Controller controller)
        {
            var cookieUser = controller.Request.Cookies[CookieConstants.CookieEmail];
            var cookiePass = controller.Request.Cookies[CookieConstants.CookiePass];

            cookieUser.Expires = DateTime.Now.AddMinutes(CookieConstants.TimeToCookieExpired);
            cookiePass.Expires = DateTime.Now.AddMinutes(CookieConstants.TimeToCookieExpired);

            controller.Response.Cookies.Add(cookieUser);
            controller.Response.Cookies.Add(cookiePass);
        }

        public static string RetrieveCookieEmail(this Controller controller)
        {
            var cookie = controller.Request.Cookies[CookieConstants.CookieEmail];
            try
            {
                if(cookie.IsNotNull())
                    return FormsAuthentication.Decrypt(cookie.Value).Name;
            }
            catch (Exception)
            {
                if (cookie.IsNotNull())
                    RemoveCookie(controller);
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
                    RemoveCookie(controller);
            }
            return string.Empty;
        }

        public static string RetrieveCookieLenguage(this Controller controller)
        {
            var cookie = controller.Request.Cookies[CookieConstants.CookieLenguage];
            try
            {
                if (cookie.IsNotNull())
                    return FormsAuthentication.Decrypt(cookie.Value).Name;
            }
            catch (Exception e)
            {
                if (cookie.IsNotNull())
                    RemoveCookie(controller);
            }
            return string.Empty;
        }

        public static bool ExistsCookieEmail(this Controller controller)
        {
            return controller.RetrieveCookieEmail().IsNotNullOrEmpty();
        }

        public static bool ExistsCookiePassword(this Controller controller)
        {
            return controller.RetrieveCookiePassword().IsNotNullOrEmpty();
        }

        public static bool ExistsCookieLenguage(this Controller controller)
        {
            return controller.RetrieveCookieLenguage().IsNotNullOrEmpty();
        }
    }
}