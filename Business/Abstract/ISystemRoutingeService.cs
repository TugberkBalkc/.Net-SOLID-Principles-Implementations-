using Core.Utilities.Results.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface ISystemRoutingeService
    {
        IResult DisableAccess();
        IResult DisableAccess(int lockingTimeInMinutes);
        IResult DisableAccess(int lockingTimeInMinutes,string Message);
        IResult OpenAccess();
    }
}
