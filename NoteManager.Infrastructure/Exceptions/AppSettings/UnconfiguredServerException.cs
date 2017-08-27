using System;
using NoteManager.Infrastructure.Constants;

namespace NoteManager.Infrastructure.Exceptions.AppSettings
{
    [Serializable]
    public class UnconfiguredServerException : Exception
    {
        public UnconfiguredServerException()
            : base(ExceptionConstants.UnconfiguredServer)
        {
        }
    }
}