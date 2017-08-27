using System.Web;
using NoteManager.Infrastructure.Strings;

namespace NoteManager.Infrastructure.Settings
{
    public static class RootResolver
    {
        public static string Resolver
        {
            get
            {
                var request = HttpContext.Current.Request;
                var scheme = request.Url.Scheme;
                var server = request.Url.Authority;
                var application = request.ApplicationPath.IsEqualTo("/") ? "" : request.ApplicationPath;
                return $"{scheme}://{server}{application}/";
            }
        }
    }
}