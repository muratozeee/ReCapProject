using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results
{
    //<T> it means what type of return say me ...:)
    public interface IDataResult<T>:IResult
    {
        T Data { get; }

    }
}
