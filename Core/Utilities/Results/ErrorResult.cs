using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorResult : Result
    { 
        //We will do overloading methods to use different options...
        //it means if it is true you can send the message...
        public ErrorResult(string message) : base(false, message)
        {

        }

        //it means you can send the default message... if it is true
        public ErrorResult() : base(false)
        {

        }
    }
}
