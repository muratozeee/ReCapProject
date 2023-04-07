using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    public class DataResult<T>:Result,IDataResult<T>
    {
        //we returned the data,succes and message and also it will be base class samely...
        //also we can not call the data from somewhere that's why we have to write like that Data=data; 
        public DataResult(T data,bool success,string message ):base(success,message) 
        {
            Data = data;   
        }
        
        //withod message can come and we did the overloading...
        public DataResult(T data,bool success):base(success)
        {
            Data = data;

        }
        public T Data { get; }

    }
}
