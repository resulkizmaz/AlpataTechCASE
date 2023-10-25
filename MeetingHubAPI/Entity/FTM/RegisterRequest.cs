
using Microsoft.AspNetCore.Http;

namespace Entity
{
    //Frontend'den gelen
    public class RegisterRequest :IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public IFormFile ProfileImage { get; set; }
    }

    //Veri tabanı için dönüşen
    public class RegisterTransferObject : IDTO
    {

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Phone { get; set; }
        public string ProfileImagePath { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
    }
}
