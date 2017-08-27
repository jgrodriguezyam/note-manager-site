using System;
using NoteManager.Infrastructure.Constants;

namespace NoteManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class MethodNotAllowedException:Exception
    {
        public MethodNotAllowedException()
            : base(ExceptionConstants.MethodNotAllowed)
        {
            
        }
    }
}