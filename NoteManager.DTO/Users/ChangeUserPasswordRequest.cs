namespace NoteManager.DTO.Users
{
    public class ChangeUserPasswordRequest
    {
         public string UserName { get; set; }
         public string OldPassword { get; set; }
         public string NewPassword { get; set; }
    }
}