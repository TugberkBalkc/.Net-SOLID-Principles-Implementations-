using Core.Utilities.Results.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ICategoryAmountService
    {
         IResult CheckStatus();
    }
}
