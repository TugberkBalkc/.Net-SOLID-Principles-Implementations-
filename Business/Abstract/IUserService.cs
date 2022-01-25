using Core.Entities.Concrete;
using Core.Utilities.Results.DataResult;
using Core.Utilities.Results.Result;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Business.Abstract
{
    public interface IUserService
    {
        IDataResult<User> GetUserByEmail(string email);
        IDataResult<List<User>> GetUsers();
        IDataResult<List<OperationClaim>> GetClaims(User user);
        IResult Add(User user);
        IResult Delete(User user);
        IResult Update(User user);


    }
}
