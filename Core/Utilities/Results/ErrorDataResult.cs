using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        //we returned the data,false and message in dataResult 
        public ErrorDataResult(T data, string message) : base(data, false, message)
        {

        }
        //we can return just data and false 
        public ErrorDataResult(T data) : base(data, false)
        {

        }
        //we can just return the default for data and false with message
        public ErrorDataResult(string message) : base(default, false, message)
        {

        }

        //we return the default data, false and defult message...!

        public ErrorDataResult() : base(default, false)
        {

        }
    }
}
