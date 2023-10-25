﻿using Core.Server;
using Entity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business
{
    public interface IAuthenticationService
    {
        Task<FormResult<UserRegisterResult>> RegisterUser(RegisterRequest request);
    }
}
