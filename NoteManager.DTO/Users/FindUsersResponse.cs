using System.Collections.Generic;
using NoteManager.DTO.BaseResponse;

namespace NoteManager.DTO.Users
{
    public class FindUsersResponse : FindBaseResponse
    {
        public FindUsersResponse()
        {
            Users = new List<UserResponse>();
        }

        public List<UserResponse> Users { get; set; }
    }
}