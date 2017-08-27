using System;
using System.Net;
using NoteManager.Infrastructure.Client.BaseResponse;
using NoteManager.Infrastructure.Dictionaries;
using NoteManager.Infrastructure.Exceptions.Client;
using NoteManager.Infrastructure.Exceptions.Enums;
using NoteManager.Infrastructure.Exceptions.Messages;
using NoteManager.Infrastructure.Strings;
using RestSharp;

namespace NoteManager.Infrastructure.Client
{
    public static class Response
    {
        public static void ValidateStatus(IRestResponse response)
        {
            var messageException = string.Empty;
            switch (response.StatusCode)
            {
                case HttpStatusCode.OK:
                    ChangeKey(response);
                    break;
                case HttpStatusCode.Accepted:
                    ChangeKey(response);
                    messageException = GetMessageException(response.Content);
                    throw new AcceptedException(messageException);
                case HttpStatusCode.Unauthorized:
                    messageException = GetMessageException(response.Content);
                    throw new UnauthorizedException(messageException);
                case HttpStatusCode.NotFound:
                    messageException = GetMessageException(response.Content);
                    throw new NotFoundException(messageException);
                case HttpStatusCode.PreconditionFailed:
                    messageException = GetMessageException(response.Content);
                    throw new PreconditionFailedException(messageException);
                case HttpStatusCode.NotAcceptable:
                    messageException = GetMessageException(response.Content);
                    throw new NotAcceptableException(messageException);
                case HttpStatusCode.Conflict:
                    messageException = GetMessageException(response.Content);
                    throw new ConflictException(messageException);
                default:
                    var typeArgument = ExceptionDictionary.ExceptionTypeToStatusCode[response.StatusCode];
                    throw (Exception) Activator.CreateInstance(typeArgument);
            }
        }

        private static void ChangeKey(IRestResponse response)
        {
            //var headerPublicKey = response.Headers[0].Value.ToString();
            //SessionSettings.AssignPublicKey(headerPublicKey);
        }

        private static string GetMessageException(string contentResponse)
        {
            var exceptionResponse = contentResponse.Deserialize<ExceptionResponse>();
            switch (exceptionResponse.ErrorCode)
            {
                case EErrorCode.NotFound:
                     return MessageException.NotFound;
                case EErrorCode.InvalidCredential:
                    return MessageException.InvalidCredential;
                case EErrorCode.UnauthorizedChangePassword:
                    return MessageException.UnauthorizedChangePassword;
                case EErrorCode.Conflict:
                    return MessageException.Conflict;
                case EErrorCode.InvalidKey:
                    return MessageException.InvalidKey;
                case EErrorCode.InvalidTimespan:
                    return MessageException.InvalidTimespan;
                case EErrorCode.InvalidSerial:
                    return MessageException.InvalidSerial;
                case EErrorCode.InvalidDate:
                    return MessageException.InvalidDate;
                case EErrorCode.AlreadyHasAddress:
                    return MessageException.AlreadyHasAddress;
                case EErrorCode.IsZero:
                    return MessageException.IsZero;
                case EErrorCode.IsNotZero:
                    return MessageException.IsNotZero;
                case EErrorCode.InvalidIdentifier:
                    return MessageException.InvalidIdentifier;
                case EErrorCode.AlreadyHasAccountStatementFile:
                    return MessageException.AlreadyHasAccountStatementFile;
                case EErrorCode.AlreadyHasProofFile:
                    return MessageException.AlreadyHasProofFile;
                case EErrorCode.MailAlreadyExists:
                    return MessageException.MailAlreadyExists;
                case EErrorCode.SurveyIsAlreadyAssigned:
                    return MessageException.SurveyIsAlreadyAssigned;
                case EErrorCode.UserNameAlreadyExists:
                    return MessageException.UserNameAlreadyExists;
                case EErrorCode.InvalidFile:
                    return MessageException.InvalidFile;
                case EErrorCode.FileTooLarge:
                    return MessageException.FileTooLarge;
                case EErrorCode.InvalidStatusChange:
                    return MessageException.InvalidStatusChange;
                case EErrorCode.AlreadyReferenced:
                    return MessageException.AlreadyReferenced;
                case EErrorCode.HavePendingSolicitudes:
                    return MessageException.HavePendingSolicitudes;
                case EErrorCode.HaveUnpaidsCredits:
                    return MessageException.HaveUnpaidsCredits;
                default:
                    return "Ocurrio un error";
            }
        }
    }
}