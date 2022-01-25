using Core.Entities.Concrete;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Security;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract.AuthServices
{
    public interface IAuthorizationService
    {
        IDataResult<AccessToken> CreateAccessToken(User user);
    }
}
