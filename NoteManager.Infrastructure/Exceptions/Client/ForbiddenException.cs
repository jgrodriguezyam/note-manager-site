using System;
using NoteManager.Infrastructure.Constants;

namespace NoteManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class ForbiddenException : Exception
    {
        public ForbiddenException()
            : base(ExceptionConstants.Forbidden)
        {
        }
    }
}