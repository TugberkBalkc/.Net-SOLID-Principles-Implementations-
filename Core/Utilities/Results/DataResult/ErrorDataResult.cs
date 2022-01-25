using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.DataResult
{
    public class ErrorDataResult<T> : DataResult<T>
    {
        public ErrorDataResult(T data,string message,string title) : base(data,false,message,title)
        {

        }
        public ErrorDataResult(T data,string message) : base(data,false,message)
        {

        }
        public ErrorDataResult(T data) : base(data,false)
        {

        }
        public ErrorDataResult(string message,string title) : base(default,false,message,title)
        {

        }
        public ErrorDataResult(string message) : base(default,false,message)
        {

        }
        public ErrorDataResult() : base(default,false)
        {

        }
    }
}
