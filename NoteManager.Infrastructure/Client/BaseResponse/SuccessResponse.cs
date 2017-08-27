namespace NoteManager.Infrastructure.Client.BaseResponse
{
    public class SuccessResponse
    {
        public SuccessResponse()
        {
            IsSuccess = false;
        }

        public bool IsSuccess { get; set; }
    }
}