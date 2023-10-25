using Core.Server;
using DataAccess.Services;
using Entity;

namespace Business
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly IUserDataAccessService userDataAccessService;

        public AuthenticationManager(IUserDataAccessService userDataAccessService)
        {
            this.userDataAccessService = userDataAccessService;
            
        }

        public async Task<FormResult<UserRegisterResult>> RegisterUser (RegisterRequest request)
        {
            //Gelen Image'yi ImagePath'e çevireceğiz.
            //Gelen Password'u tuzlayıp veri tabanına gömeceğiz.
            //Diğer değerler direkt veri tabanına gidecek.
            try
            {

                
                return new FormResult<UserRegisterResult>(true, "Success", null, null);
            }
            catch (Exception ex)
            {
                return new FormResult<UserRegisterResult>(false, ex.Message, null, null);
            }
        }





    }
}
