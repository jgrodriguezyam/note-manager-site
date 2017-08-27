using System;
using NoteManager.Infrastructure.Constants;

namespace NoteManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class ExpectationFailedException:Exception
    {
        public ExpectationFailedException()
            : base(ExceptionConstants.ExpectationFailed)
        {
            
        }
    }
}