using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Results.Result
{
    public class SuccessfulResult : Result
    {
        public SuccessfulResult(string message, string title) : base(true,title,message)
        {

        }
        public SuccessfulResult(string message) : base(true,message)
        {

        }
        public SuccessfulResult() : base(true)
        {

        }
    }
}
