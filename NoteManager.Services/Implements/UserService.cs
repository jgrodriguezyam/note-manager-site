using NoteManager.Services.Interfaces;
using NoteManager.DTO.Users;
using NoteManager.Infrastructure.Client;
using NoteManager.Infrastructure.Constants;
using NoteManager.Infrastructure.Settings;

namespace NoteManager.Services.Implements
{
    public class UserService : IUserService
    {
        public FindUsersResponse Find(FindUsersRequest request)
        {
            var uri = string.Format(PluralEntityConstants.Users);
            return Request.Filter<FindUsersResponse>(uri, request);
        }

        public void Create(UserRequest request)
        {
            var uri = string.Format(PluralEntityConstants.Users);
            var response = Request.Post(uri, request);
            request.Id = response.Id;
        }

        public void Update(UserRequest request)
        {
            var uri = string.Format(PluralEntityConstants.Users);
            Request.Put(uri, request);
        }

        public UserResponse Get(int id)
        {
            var uri = string.Format("{0}/{1}", PluralEntityConstants.Users, id);
            return Request.Get<UserResponse>(uri);
        }

        public void Delete(int id)
        {
            var uri = string.Format("{0}/{1}", PluralEntityConstants.Users, id);
            Request.Delete(uri);
        }

        public LoginUserResponse Login(LoginUserRequest request)
        {
            var uriLogin = string.Format("{0}/login", PluralEntityConstants.Users);
            var loginResponse = Request.Login<LoginUserResponse>(uriLogin, request);
            SessionSettings.AssignUserId(loginResponse.UserId);
            return loginResponse;
        }

        public void Logout()
        {
            var uriLogout = string.Format("{0}/logout/{1}", PluralEntityConstants.Users, SessionSettings.RetrieveUserId);
            Request.Logout(uriLogout);
        }

        public void ChangePassword(ChangeUserPasswordRequest request)
        {
            var uri = string.Format("{0}/change-password", PluralEntityConstants.Users);
            Request.Post(uri, request);
        }

        public void RestorePassword(RestorePasswordRequest request)
        {
            var uri = string.Format("{0}/restore-password", PluralEntityConstants.Users);
            Request.Post(uri, request);
        }
    }
}