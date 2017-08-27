using System;
using NoteManager.Infrastructure.Constants;

namespace NoteManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class BadRequestException : Exception
    {
        public BadRequestException()
            : base(ExceptionConstants.BadRequest)
        {
        }
    }
}