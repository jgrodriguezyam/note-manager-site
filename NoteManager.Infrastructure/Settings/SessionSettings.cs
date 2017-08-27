using System;
using System.Web;
using NoteManager.Infrastructure.Constants;
using NoteManager.Infrastructure.Dates;
using NoteManager.Infrastructure.Integers;

namespace NoteManager.Infrastructure.Settings
{
    public static class SessionSettings
    {
        #region Assign

        public static void AssignAllSessions()
        {
            if (!ExistsUserId)
            {
                AssignTicks();
                AssignUserId(0);
                AssignUserName(string.Empty);
                AssignCustomerId(0);
            }
        }

        public static void AssignTicks()
        {
            HttpContext.Current.Session.Add(SessionConstants.Ticks, DateConvert.GetTicksNow());
        }

        public static void AssignUserId(int userId)
        {
            HttpContext.Current.Session.Add(SessionConstants.UserId, userId);
        }

        public static void AssignUserName(string userName)
        {
            HttpContext.Current.Session.Add(SessionConstants.UserName, userName);
        }

        public static void AssignCustomerId(int customerId)
        {
            HttpContext.Current.Session.Add(SessionConstants.CustomerId, customerId);
        }

        public static void AssignWorkerId(int workerId) {
            HttpContext.Current.Session.Add(SessionConstants.WorkerId, workerId);
        }

        #endregion

        #region Retrieve

        public static string RetrieveTicks
        {
            get { return HttpContext.Current.Session[SessionConstants.Ticks].ToString(); }
        }

        public static int RetrieveUserId
        {
            get { return Convert.ToInt32(HttpContext.Current.Session[SessionConstants.UserId]); }
        }

        public static string RetrieveUserName
        {
            get { return HttpContext.Current.Session[SessionConstants.UserName].ToString(); }
        }

        public static int RetrieveCustomerId
        {
            get { return Convert.ToInt32(HttpContext.Current.Session[SessionConstants.CustomerId]); }
        }

        public static int RetrieveWorkerId
        {
            get { return Convert.ToInt32(HttpContext.Current.Session[SessionConstants.WorkerId]); }
        }

        #endregion

        #region Remove

        public static void RemoveAllSessions()
        {
            HttpContext.Current.Session.RemoveAll();
        }

        #endregion

        #region Exists

        public static bool ExistsUserId
        {
            get
            {
                try
                {
                    return RetrieveUserId.IsGreaterThanZero();
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool ExistsCustomerId
        {
            get
            {
                try
                {
                    return RetrieveCustomerId.IsGreaterThanZero();
                }
                catch
                {
                    return false;
                }
            }
        }

        public static bool ExistsWorkerId
        {
            get
            {
                try
                {
                    return RetrieveWorkerId.IsGreaterThanZero();
                }
                catch
                {
                    return false;
                }
            }
        }

        #endregion
    }
}