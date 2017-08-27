﻿using System;

namespace NoteManager.Infrastructure.Exceptions.Client
{
    [Serializable]
    public class NotAcceptableException : Exception
    {
        public NotAcceptableException()
        {

        }

        public NotAcceptableException(string message)
            : base(message)
        {

        }
    }
}