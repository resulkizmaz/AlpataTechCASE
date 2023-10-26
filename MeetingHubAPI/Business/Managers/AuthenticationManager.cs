using Core.Rules;
using Core.Server;
using Core.Server.JWT;
using DataAccess.Services;
using Entity;
using Microsoft.Extensions.Options;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace Business
{
    public class AuthenticationManager : IAuthenticationService
    {

        private readonly JwtConfigurationsModel jwtOptions;
        private readonly IUserDataAccessService userDataAccessService;
        private readonly IUploadService uploadService;

        public AuthenticationManager(IUserDataAccessService userDataAccessService,IUploadService uploadService, IOptions<JwtConfigurationsModel> jwtOptions)
        {
            this.userDataAccessService = userDataAccessService;
            this.uploadService = uploadService;
            this.jwtOptions = jwtOptions.Value;

        }

        public string CreateJWT( UserLoginResult loginResult)
        {
            if (jwtOptions.Secret == null) throw new Exception("JWT ayarlarındaki key null olamaz!");
            
            var securityKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtOptions.Secret));
            var cradentials = new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha256);

            var claims = new Claim[]
            {
                new Claim(JwtRegisteredClaimNames.Email,loginResult.Email)
            };

            var token = new JwtSecurityToken(jwtOptions.ValidIssuer,
                jwtOptions.ValidAudience,
                claims,
                expires: DateTime.Now.AddHours(2),
                signingCredentials : cradentials);

            return new JwtSecurityTokenHandler().WriteToken(token);
        }

        public async Task<FormResult<string>> RegisterUser (RegisterRequest request)
        {
            //Gelen Image'yi ImagePath'e çevireceğiz.
            //Gelen Password'u tuzlayıp veri tabanına gömeceğiz.
            //Diğer değerler direkt veri tabanına gidecek.
            try
            {
                string path = await this.uploadService.UploadSubscriberDocument(request.ProfileImage);
                string salt = Encryptions.CreateSalt(88);
                string firstHash = Encryptions.SHA512Hashing(request.Password, salt);
                //Frontendden gelen obje transfer objeye dönüştürülür. 
                RegisterTransferObject transfer = new RegisterTransferObject
                {
                    Email = request.Email,
                    PasswordSalt = salt,
                    PasswordHash = Encryptions.SHA512Hashing(firstHash, salt), // bir tur daha dönüm iterasyonu arttırabiliriz.
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
            catch (Exception ex)
            {
                return new FormResult<string>(false, ex.Message, null, null);
            }
        }

        public async Task<FormResult<LoginFTO>> UserLogIn(string email, string password)
        {
            try
            {
                if (string.IsNullOrEmpty(password) || string.IsNullOrEmpty(email))
                    return new FormResult<LoginFTO>(false,"Null Value!",null,null);

                UserInfoResult userInfoResult = await this.userDataAccessService.GetPasswordInfo(email);
                if (!userInfoResult.Success)
                    return new FormResult<LoginFTO>(false, "No password exist.", null, null);

                string salt = userInfoResult.PasswordSalt;
                string requestedHash = Encryptions.SHA512Hashing(Encryptions.SHA512Hashing(password, salt),salt); // kayıt sırasında 2 iterasyon var.
                string realHash = userInfoResult.PasswordHash;

                if (realHash != requestedHash)
                    return new FormResult<LoginFTO>(false, "Passwords do not match", null, null);

                


                UserLoginResult loginResult = await this.userDataAccessService.UserLogIn(email);
                if (!loginResult.Success)
                    return new FormResult<LoginFTO>(false, "", null, null);
                
                //Token Oluşturma
                string token = CreateJWT(loginResult);

                LoginFTO resultFTO = new LoginFTO {
                    Email = loginResult.Email,
                    Name = loginResult.Name,
                    Phone = loginResult.Phone,
                    Success = loginResult.Success,
                    ProfileImage = null,
                    Token = token

                };
                return new FormResult<LoginFTO>(true,"Hoş Geldiniz "+resultFTO.Name, resultFTO, null);

            }
            catch (Exception ex)
            {
                return new FormResult<LoginFTO>(false, ex.Message, null, null);
            }
        }



    }
}
