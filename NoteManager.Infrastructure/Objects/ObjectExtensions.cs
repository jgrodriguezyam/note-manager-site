using System;
using System.Collections.Generic;
using System.Dynamic;
using System.Linq;
using System.Web.Script.Serialization;

namespace NoteManager.Infrastructure.Objects
{
    public static class ObjectExtensions
    {
        public static bool IsNull(this object value)
        {
            return value == null;
        }

        public static bool IsNotNull(this object value)
        {
            return !IsNull(value);
        }

        public static Dictionary<string, string> ConvertToDictionary(this object value)
        {
            if (value.IsNull())
                return null;

            var dictionary = (from x in value.GetType().GetProperties() select x).ToDictionary(x => x.Name,
                x => (x.GetGetMethod().Invoke(value, null) == null ? "" : x.GetGetMethod().Invoke(value, null).ToString()));
            return dictionary;
        }

        public static T ExtractProperty<T>(this object @object, string property)
        {
            return (T)@object.GetType().GetProperty(property).GetValue(@object, null);
        }

        public static Object ExtractProperty(this object @object, string property)
        {
            return @object.GetType().GetProperty(property).GetValue(@object, null);
        }

        public static Object Serialize(this object @object)
        {
            return new JavaScriptSerializer().Serialize(@object);
        }
    }
}