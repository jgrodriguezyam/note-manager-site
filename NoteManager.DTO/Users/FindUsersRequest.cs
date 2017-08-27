using NoteManager.DTO.BaseRequest;

namespace NoteManager.DTO.Users
{
    public class FindUsersRequest : FindBaseRequest
    {
        public string UserName { get; set; }
    }
}