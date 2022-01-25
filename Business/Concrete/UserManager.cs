using Business.Abstract;
using Business.BusinessAspects.Autofac;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result;
using DataAccess.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class UserManager : IUserService
    {
        private readonly IUserDal _userDal;
        private readonly ISystemRoutingeService _routingeService; 

        public UserManager
            (IUserDal userDal,
            ISystemRoutingeService routingeService)
        {
            _userDal = userDal;
            _routingeService = routingeService;
        }


        public IResult Add(User user)
        {
            _userDal.Add(user);
            return new SuccessfulResult(Messages.UserAdded);
        }

        public IResult Delete(User user)
        {
            _userDal.Delete(user);
            return new SuccessfulResult(Messages.UserDeleted);
        }

        public IDataResult<List<OperationClaim>> GetClaims(User user)
        {
            var result = _userDal.GetClaims(user);
            return result.Count == 0
                 ? new ErrorDataResult<List<OperationClaim>>(result, Titles.Error, Messages.ClaimsCouldNotListed)
                 : new SuccessfulDataResult<List<OperationClaim>>(result);
        }

        public IDataResult<User> GetUserByEmail(string email)
        {
            var result = _userDal.Get(u=>u.Email == email);
            return result == null
                 ? new ErrorDataResult<User>(result, Titles.Error, Messages.UserNotFound)
                 : new SuccessfulDataResult<User>(result);
        }

        public IDataResult<List<User>> GetUsers()
        {
            var result = _userDal.GetAll();
            return result.Count == 0
                 ? new ErrorDataResult<List<User>>(result, Titles.Error, Messages.UsersCouldNotListed)
                 : new SuccessfulDataResult<List<User>>(result);
        }

        public IResult Update(User user)
        {
            _userDal.Update(user);
            return new SuccessfulResult(Titles.TransactionSuccessful, Messages.UserUpdated);
        }

        [SecuredOperationAspect("admin")]
        public IResult LockSystem()
        {
            return _routingeService.DisableAccess();
        }

        [SecuredOperationAspect("admin")]
        public IResult LockSystem(int lockingTimeInMinutes,string operationCode)
        {
            return _routingeService.DisableAccess(lockingTimeInMinutes);
        }

       /* [SecuredOperationAspect("admin")]
        public IResult LockSystem(int lockingTimeInMinutes,string message)
        {
           return  _routingeService.DisableAccess(lockingTimeInMinutes, message);
        }*/
    }
}
