using NoteManager.DTO.BaseResponse;

namespace NoteManager.DTO.Users
{
    public class LoginUserResponse : LoginResponse
    {
        public int UserId { get; set; }
    }
}