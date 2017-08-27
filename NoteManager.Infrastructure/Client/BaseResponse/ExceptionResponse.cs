using NoteManager.Infrastructure.Exceptions.Enums;

namespace NoteManager.Infrastructure.Client.BaseResponse
{
    public class ExceptionResponse
    {
        public ExceptionResponse()
        {
            Message = "";
        }

        public string Message { get; set; }
        public EErrorCode ErrorCode { get; set; }
    }
}