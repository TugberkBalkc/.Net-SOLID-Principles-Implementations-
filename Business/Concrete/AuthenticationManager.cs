using Business.Abstract;
using Business.Abstract.AuthServices;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Business;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result;
using Core.Utilities.Security;
using Core.Utilities.Security.Hashing;
using Entities.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthenticationManager : AuthBase, IAuthenticationService
    {

        public AuthenticationManager(IUserService userService, ITokenHelper tokenHelper) : base(userService,tokenHelper)
        {

        }


        public IDataResult<User> Login(UserForLoginDto userForLoginDto)
        {
            var user = UserExists(userForLoginDto.Email);
            if (user.Success == false) return new ErrorDataResult<User>(Messages.UserNotFound, Titles.Error);

            var logicResut = BusinessLogicEngine.
                Run(CheckIfUserVerified
                    (userForLoginDto.Password,user.Data.PasswordHash,user.Data.PasswordSalt)
                    );

            var result = BusinessLogicEngine.Decider<User>(user.Data, logicResut);

            return result.Success == false 
                ? result 
                : new SuccessfulDataResult<User>(user.Data, Titles.TransactionSuccessful, Messages.LoggedInSuccessfully);
        }

        public IDataResult<User> Register(UserForRegisterDto userForRegisterDto)
        {
            byte[] passwordHash, passwordSalt;
            HashingHelper.CreatePasswordHash(userForRegisterDto.Password, out passwordHash, out passwordSalt);
            var user = new User
            {
                Email = userForRegisterDto.Email,
                FirstName = userForRegisterDto.FirstName,
                LastName = userForRegisterDto.LastName,
                PasswordHash = passwordHash,
                PasswordSalt = passwordSalt,
                Status = true
            };
            _userService.Add(user);
            return new SuccessfulDataResult<User>(user,Titles.TransactionSuccessful,Messages.RegisteredSuccessfully);
        }


        public IDataResult<User> UserExists(string email)
        {
            var result = _userService.GetUserByEmail(email);
            if (!result.Success)
            {
                return new ErrorDataResult<User>(result.Message);
            }
            return new SuccessfulDataResult<User>(result.Data);
        }

        public IResult CheckIfUserVerified(string password,byte[] passwordHash,byte[] passwordSalt)
        {
            if (!HashingHelper.VerifyPasswordHash(password,passwordHash,passwordSalt))
            {
                return new ErrorResult(Titles.Error, Messages.UserNotVerified);
            }
            return new SuccessfulResult();
        }
    }
}
