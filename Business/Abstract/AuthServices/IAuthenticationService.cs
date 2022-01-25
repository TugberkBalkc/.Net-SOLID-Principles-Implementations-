using Core.Entities.Concrete;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result;
using Entities.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.AuthServices
{
    public interface IAuthenticationService
    {
        IDataResult<User> Login(UserForLoginDto userForLoginDto);
        IDataResult<User> Register(UserForRegisterDto userForRegisterDto);
        IDataResult<User> UserExists(string email);
    }
}
