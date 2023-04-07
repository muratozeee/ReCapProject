using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class SuccessDataResult<T>:DataResult<T>
    {
        //we returned the data,true and message in dataResult 
        public SuccessDataResult(T data,string message):base(data,true,message)
        {
            
        }
        //we can return just data and true 
        public SuccessDataResult(T data):base(data,true)
        {
            
        }
        //we can just return the default for data and true with message
        public SuccessDataResult(string message):base(default,true,message)
        {
            
        }
        
        //we return the default data, true and defult message...!

        public SuccessDataResult():base(default,true)
        {
            
        }
    }
}
