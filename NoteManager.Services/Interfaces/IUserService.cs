using NoteManager.DTO.Users;

namespace NoteManager.Services.Interfaces
{
    public interface IUserService
    {
        FindUsersResponse Find(FindUsersRequest request);
        void Create(UserRequest request);
        void Update(UserRequest request);
        UserResponse Get(int id);
        void Delete(int id);
        LoginUserResponse Login(LoginUserRequest request);
        void Logout();
        void ChangePassword(ChangeUserPasswordRequest request);
        void RestorePassword(RestorePasswordRequest request);

    }
}