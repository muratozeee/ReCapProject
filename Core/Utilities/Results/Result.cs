using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{

    public class Result : IResult
    {
       
        //we can set in same constructure that's why no need to use set; in properties...
        //this=use the this class succes variable...it means Result..!
        //base=use the base class variable it means IResult..!
        public Result(bool success, string message):this(success) 
        {
          Message = message;
         
        }

        //some time we just checking true or false that's why
        //we used the overloading method...
        public Result(bool success)
        {
            
            Success = success;
        }


        public bool Success { get; }
        public string Message { get; }

    }
}
