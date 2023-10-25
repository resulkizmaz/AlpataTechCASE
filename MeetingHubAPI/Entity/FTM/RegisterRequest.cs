
using Microsoft.AspNetCore.Http;

namespace Entity
{
    public class RegisterRequest :IDTO
    {
        public string Email { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Phone { get; set; }
        public IFormFile ProfileImage { get; set; }
    }
}
