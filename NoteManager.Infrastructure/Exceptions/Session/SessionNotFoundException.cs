using System;
using NoteManager.Infrastructure.Constants;

namespace NoteManager.Infrastructure.Exceptions.Session
{
    [Serializable]
    public class SessionNotFoundException : Exception
    {
        public SessionNotFoundException()
            : base(ExceptionConstants.SessionNotFound)
        {
        }
    }
}