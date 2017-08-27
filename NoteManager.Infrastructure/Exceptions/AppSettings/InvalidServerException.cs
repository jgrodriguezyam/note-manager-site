using System;
using NoteManager.Infrastructure.Constants;

namespace NoteManager.Infrastructure.Exceptions.AppSettings
{
    [Serializable]
    public class InvalidServerException : Exception
    {
        public InvalidServerException()
            : base(ExceptionConstants.InvalidServer)
        {
        }
    }
}