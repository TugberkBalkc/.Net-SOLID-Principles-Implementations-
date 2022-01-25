using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Result
{
    public class Result : IResult
    {
        public Result(bool success,string title,string message) : this(success)
        {
            Title = title;
            Message = message;
        }
        public Result(bool success, string message) : this(success)
        {
            Message = message;
        }
        public Result(bool success)
        {
            Success = success;
        }
        public bool Success { get; }

        public string Title { get; }

        public string Message { get; }
    }
}
