using Business.Abstract;
using Business.Abstract.AuthServices;
using Business.Constants;
using Core.Entities.Concrete;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthorizationManager : AuthBase, IAuthorizationService
    {
        public AuthorizationManager(IUserService userService, ITokenHelper tokenHelper) : base(userService, tokenHelper)
        {

        }


        public IDataResult<AccessToken> CreateAccessToken(User user)
        {
            var operationClaims = _userService.GetClaims(user);
            var token = _tokenHelper.CreateToken(user, operationClaims.Data);
            return new SuccessfulDataResult<AccessToken>(token, Messages.AccessTokenCreated);
        }
    }
}
