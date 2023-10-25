using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entity
{
    public class RegisterTransferObject :IDTO
    {

        public string Email { get; set; }
        public string PasswordHash { get; set; }
        public string PasswordSalt { get; set; }
        public string Phone { get; set; }
        public string ProfileImagePath { get; set; }
        public string Name { get; set; }
        public string Surname { get; set;}
    }


    
}
