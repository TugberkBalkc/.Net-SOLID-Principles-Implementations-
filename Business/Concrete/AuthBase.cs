using Business.Abstract;
using Core.Utilities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Concrete
{
    public class AuthBase
    {
        protected readonly IUserService _userService;
        protected readonly ITokenHelper _tokenHelper;

        public AuthBase(IUserService userService,ITokenHelper tokenHelper)
        {
            _userService = userService;
            _tokenHelper = tokenHelper;
        }
    }
}
