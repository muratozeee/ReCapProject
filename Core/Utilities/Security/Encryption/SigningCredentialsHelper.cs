using Microsoft.IdentityModel.Tokens;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.Encryption
{
    public class SigningCredentialsHelper
    {

        //JWT can create with credentials in WebAPI 
        //Username and Password are credentials..
        public static SigningCredentials CreateSigningCredentials(SecurityKey securityKey)
        {
            //Web API JWT is defined the which key and which algorithm will use in the system. 
            return new SigningCredentials(securityKey,SecurityAlgorithms.HmacSha512Signature);
        }
    }
}
