using System;
using System.Web.Script.Serialization;
using NoteManager.Infrastructure.Files;

namespace NoteManager.Infrastructure.Strings
{
    public static class StringExtensions
    {
        public static bool IsNullOrEmpty(this string value)
        {
            return string.IsNullOrEmpty(value);
        }

        public static bool IsNotNullOrEmpty(this string value)
        {
            return !IsNullOrEmpty(value);
        }

        public static string ToContentPath(this string self)
        {
            if (self.IsNotNullOrEmpty())
            {
                return string.Format("{0}{1}{2}", ServerDomainResolver.GetCurrentDomain(), FileSettings.ContentFolder, self);
            }
            return null;
        }

        public static bool IsEqualTo(this string value, string valueToCompare)
        {
            return value == valueToCompare;
        }

        public static bool IsNotEqualTo(this string value, string valueToCompare)
        {
            return !IsEqualTo(value, valueToCompare);
        }

        public static int ToInt(this string value)
        {
            return int.Parse(value);
        }

        public static decimal ToDecimal(this string value)
        {
            return decimal.Parse(value);
        }

        public static T Deserialize<T>(this string value)
        {
            return new JavaScriptSerializer().Deserialize<T>(value);
        }

        public static int ConvertToint(this string value)
        {
            try
            {
                var convert = Convert.ToInt32(value);
                return convert;
            }
            catch
            {
                return 0;
            }
        }
    }
}