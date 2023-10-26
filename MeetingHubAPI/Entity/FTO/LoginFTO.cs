using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    //Frontend'e gidecek olan
    public class LoginFTO
    {
        public bool Success { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public string Name { get; set; }
        public IFormFile ProfileImage { get; set; }
        public string Token { get; set; }
    }
}
