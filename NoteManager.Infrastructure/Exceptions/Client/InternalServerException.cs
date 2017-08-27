using System;
using NoteManager.Infrastructure.Constants;

namespace NoteManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class InternalServerException : Exception
    {
        public InternalServerException()
            : base(ExceptionConstants.InvalidServer)
        {
        }
    }
}