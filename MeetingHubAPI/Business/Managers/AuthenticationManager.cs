using Core.Rules;
using Core.Server;
using DataAccess.Services;
using Entity;

namespace Business
{
    public class AuthenticationManager : IAuthenticationService
    {
        private readonly IUserDataAccessService userDataAccessService;
        private readonly IUploadService uploadService;

        public AuthenticationManager(IUserDataAccessService userDataAccessService,IUploadService uploadService)
        {
            this.userDataAccessService = userDataAccessService;
            this.uploadService = uploadService;
            
        }

        public async Task<FormResult<string>> RegisterUser (RegisterRequest request)
        {
            //Gelen Image'yi ImagePath'e çevireceğiz.
            //Gelen Password'u tuzlayıp veri tabanına gömeceğiz.
            //Diğer değerler direkt veri tabanına gidecek.
            //try
            {
                string path = await this.uploadService.UploadSubscriberDocument(request.ProfileImage);
                string salt = Encryptions.CreateSalt(88);
                //Frontendden gelen obje transfer objeye dönüştürülür. 
                RegisterTransferObject transfer = new RegisterTransferObject
                {
                    Email = request.Email,
                    PasswordSalt = salt,
                    PasswordHash = Encryptions.SHA512Hashing(request.Password, salt), // bir tur daha dönüm iterasyonu arttırabiliriz.
                    Name = request.Name,
                    Surname = request.Surname,
                    Phone = request.Phone,
                    ProfileImagePath = path

                };

                UserRegisterResult result = await this.userDataAccessService.RegisterUser(transfer);
                //if (!result.Success)      eğer success değilse hangisinde hata olduğunu ayıklamak için tek tek kontrol edebiliriz.
                //{
                //    List<string> message = new List<string>();
                //}               

                if (!result.Success)
                    return new FormResult<string>(false,"Something went wrong!",null,null);
               

                return new FormResult<string>(true,"Success",result.Name,null);
            }
            //catch (Exception ex)
           // {
            //    return new FormResult<string>(false, ex.Message, null, null);
           // }
        }

        //login



    }
}
