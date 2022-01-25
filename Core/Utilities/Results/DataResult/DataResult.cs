using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.DataResult
{
    public class DataResult<TData> : IDataResult<TData>
    {
        public DataResult(TData data,bool success , string message, string title) : this(data,success,message)
        {
            Title = title;
        }
        public DataResult(TData data,bool success,string message) : this(data,success)
        {
            Message = message;
        }
        public DataResult(TData data,bool success)
        {
            Data = data;
            Success = success;
        }
        public TData Data { get; }

        public bool Success { get; }

        public string Title { get; }

        public string Message { get; }
    }
}
