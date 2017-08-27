namespace NoteManager.Infrastructure.Client.BaseResponse
{
    public class UserLoginResponse
    {
        public UserLoginResponse()
        {
            UserId = 0;
        }

        public int UserId { get; set; }
    }
}