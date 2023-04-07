using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessResult : Result
    {
        //We will do overloading methods to use different options...
        //it means if it is true you can send the message...
        public SuccessResult( string message) : base(true,message)
        {

        }
        
        //it means you can send the default message... if it is true
        public SuccessResult() : base(true)
        {

        }
        
    }
}
