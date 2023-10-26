

using Entity;

namespace DataAccess.Services
{
    public interface IUserDataAccessService
    {
        Task<UserRegisterResult> RegisterUser(RegisterTransferObject register);
        Task<UserLoginResult> UserLogIn(string email);
        Task<UserInfoResult> GetPasswordInfo(string email);

    }
}
