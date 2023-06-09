using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Security.JWT
{
    public class AccessToken
    {
        //it is token information
        public string Token { get; set; }
        //also it has time to expired we are giving time to access...
        public DateTime Expiration { get; set; }


    }
}
