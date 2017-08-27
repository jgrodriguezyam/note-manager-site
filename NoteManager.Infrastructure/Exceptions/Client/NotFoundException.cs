using System;

namespace NoteManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class NotFoundException : Exception
    {
        public NotFoundException()
        {

        }

        public NotFoundException(string message)
            : base(message)
        {

        }
    }
}