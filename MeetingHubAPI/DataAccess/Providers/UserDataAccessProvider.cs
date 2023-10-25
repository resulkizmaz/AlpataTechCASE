using DataAccess.Services;
using Entity;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;

namespace DataAccess.Providers
{
    public class UserDataAccessProvider : IUserDataAccessService
    {

        public async Task<UserRegisterResult> RegisterUser( RegisterTransferObject register)
        {
            using (MeetHubDB db = new MeetHubDB())
                return (await db.UserRegisterResults.FromSqlRaw("EXEC UserRegister @email, @passwordHash, @passwordSalt ,@phone, @imagePath, @name , @surname",
                    new SqlParameter("email",register.Email),
                    new SqlParameter("name",register.Name),
                    new SqlParameter("passwordHash", register.PasswordHash),
                    new SqlParameter("passwordSalt", register.PasswordSalt),
                    new SqlParameter("phone", register.Phone),
                    new SqlParameter("imagePath", register.ProfileImagePath),
                    new SqlParameter("email",register.Email),
                    new SqlParameter("surname", register.Surname)).ToListAsync()).FirstOrDefault();
        }

    }
}
