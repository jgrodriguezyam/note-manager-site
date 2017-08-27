using System;
using System.Collections.Generic;
using System.Net;
using NoteManager.Infrastructure.Exceptions.Client;

namespace NoteManager.Infrastructure.Dictionaries
{
    public static class ExceptionDictionary
    {
        public static readonly IDictionary<HttpStatusCode, Type> ExceptionTypeToStatusCode = new Dictionary
            <HttpStatusCode, Type>
        {
            {0, typeof (ServerNotFoundException)},
            {HttpStatusCode.BadRequest, typeof (BadRequestException)},
            {HttpStatusCode.Forbidden, typeof (ForbiddenException)},
            {HttpStatusCode.ExpectationFailed, typeof (ExpectationFailedException)},
            {HttpStatusCode.InternalServerError, typeof (InternalServerException)},
            {HttpStatusCode.MethodNotAllowed, typeof (MethodNotAllowedException)}
        };
    }
}