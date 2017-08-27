using System;
using NoteManager.Infrastructure.Constants;

namespace NoteManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class ServerNotFoundException : Exception
    {
        public ServerNotFoundException()
            : base(ExceptionConstants.ServerNotFound)
        {
        }
    }
}