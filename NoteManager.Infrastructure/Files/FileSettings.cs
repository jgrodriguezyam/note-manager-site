using System.Configuration;

namespace NoteManager.Infrastructure.Files
{
    public static class FileSettings
    {        
        public readonly static int MaximumFileSize = int.Parse(ConfigurationManager.AppSettings["MaximumFileSize"]);

        public readonly static string ContentFolder = ConfigurationManager.AppSettings["ContentMultimedia"];
    }
}