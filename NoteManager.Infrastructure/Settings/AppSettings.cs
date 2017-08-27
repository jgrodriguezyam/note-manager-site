using System.Configuration;
using NoteManager.Infrastructure.Exceptions.AppSettings;
using NoteManager.Infrastructure.Objects;
using NoteManager.Infrastructure.Strings;

namespace NoteManager.Infrastructure.Settings
{
    public static class AppSettings
    {
        public static string ServerApi
        {
            get
            {
                var serverApi  =  ConfigurationManager.AppSettings["ServerApi"];
                if(serverApi.IsNullOrEmpty())
                    throw  new UnconfiguredServerException();
                return serverApi;
            }
        }

        public static string Serial
        {
            get
            {
                return ConfigurationManager.AppSettings["Serial"];
            }
        }

        public static string AllowedFileExtensions
        {
            get
            {
                return ConfigurationManager.AppSettings["AllowedFileExtensions"];
            }
        }

        public static int MaxRequestLength
        {
            get
            {
                return ConfigurationManager.GetSection("system.web/httpRuntime").ExtractProperty<int>("MaxRequestLength");
            }
        }
    }
}