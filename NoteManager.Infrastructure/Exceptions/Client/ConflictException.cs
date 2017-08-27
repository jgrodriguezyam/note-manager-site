using System;
using NoteManager.Infrastructure.Constants;

namespace NoteManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class ConflictException : Exception
    {
        public ConflictException(): base(ExceptionConstants.Conflict)
        {
        }

        public ConflictException(string message)
            : base(message)
        {

        }
    }

}