﻿using Microsoft.IdentityModel.Tokens;
using System.Text;

namespace PatientLog.Service.Helper
{
    public class SignService
    {
        public static SecurityKey GetSymmetricSecurityKey(string securityKey)
          => new SymmetricSecurityKey(Encoding.UTF8.GetBytes(securityKey));
    }
}
