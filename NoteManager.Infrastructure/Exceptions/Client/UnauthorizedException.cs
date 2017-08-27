using System;

namespace NoteManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class UnauthorizedException : Exception
    {
        public UnauthorizedException()
        {

        }

        public UnauthorizedException(string message)
            : base(message)
        {

        }
    }
}