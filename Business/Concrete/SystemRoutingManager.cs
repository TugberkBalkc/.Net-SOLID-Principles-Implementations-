using Business.Abstract;
using Business.Constants;
using Core.Utilities.Interceptors.CastleDynamicProxy;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class SystemRoutingManager : ISystemRoutingeService
    {
        public IResult DisableAccess()
        {
            var unlockingDate = DateTime.Now.AddDays(100000);
            if (DateTime.Now != unlockingDate)
            {
                return new ErrorDataResult<DateTime>(unlockingDate, Messages.SystemLockedUntil(unlockingDate), Titles.Error);
            }

            return new SuccessfulDataResult<DateTime>(unlockingDate);
        }

        public IResult DisableAccess(int lockingTimeInMinutes)
        {
            var unlockingDate = DateTime.Now.AddMinutes(lockingTimeInMinutes);
            if (DateTime.Now != unlockingDate)
            {
                return new ErrorDataResult<DateTime>(unlockingDate, Messages.SystemLockedUntil(unlockingDate), Titles.Error);
            }

            return new SuccessfulDataResult<DateTime>(unlockingDate);
        }

        public IResult DisableAccess(int lockingTimeInMinutes, string message)
        {
            var unlockingDate = DateTime.Now.AddMinutes(lockingTimeInMinutes);
            if (DateTime.Now != unlockingDate)
            {
                return new ErrorDataResult<DateTime>(unlockingDate, message, Titles.Error);
            }

            return new SuccessfulDataResult<DateTime>(unlockingDate);
        }

        public IResult OpenAccess()
        {
            var unlockingDate = DateTime.Now;
            if (DateTime.Now != unlockingDate)
            {
                return new ErrorDataResult<DateTime>(unlockingDate, Messages.SystemLockedUntil(unlockingDate), Titles.Error);
            }

            return new SuccessfulDataResult<DateTime>(unlockingDate);
        }
    }
}
