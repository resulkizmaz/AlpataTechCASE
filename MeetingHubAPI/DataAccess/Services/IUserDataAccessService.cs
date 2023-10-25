

using Entity;

namespace DataAccess.Services
{
    public interface IUserDataAccessService
    {
        Task<UserRegisterResult> RegisterUser(RegisterTransferObject register);

    }
}
