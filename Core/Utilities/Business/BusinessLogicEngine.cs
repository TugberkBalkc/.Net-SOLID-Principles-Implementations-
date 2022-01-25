using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Business
{
    public class BusinessLogicEngine
    {

        public static DataResult<T> Decider<T>(T returnValue, IResult logicEnginesResult)
        {
            if (logicEnginesResult != null)
            {
                return new ErrorDataResult<T>(returnValue,logicEnginesResult.Message, "Error");
            }
            return new SuccessfulDataResult<T>(returnValue);
        }

        public static Result Decider(IResult logicEnginesResult)
        {
            if (logicEnginesResult != null)
            {
                return new ErrorResult(logicEnginesResult.Message, "Error");
            }
            return new SuccessfulResult();
        }

        public static IResult Run(params IResult[] logics)
        {
            foreach (var logic in logics)
            {
                if (!logic.Success)
                {
                    return logic;
                }
            }
            return null;
        }
    }
}
