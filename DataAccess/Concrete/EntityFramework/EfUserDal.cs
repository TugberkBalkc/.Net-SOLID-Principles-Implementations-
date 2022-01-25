using Core.DataAccess.EntityFramework;
using Core.Entities.Concrete;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework.Contexts;
using Entities.Dto_s;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess.Concrete.EntityFramework
{
    public class EfUserDal : EfEntityRepositoryBase<User,NorthwindETradeContext> , IUserDal
    {
        public List<OperationClaim> GetClaims(User user)
        {
            using (var context = new NorthwindETradeContext())
            {
                var result = from operationClaim in context.OperationClaims
                             join userOperatiomClaim in context.UserOperationClaims
                             on operationClaim.Id equals userOperatiomClaim.OperationClaimId
                             where userOperatiomClaim.UserId == user.Id
                             select new OperationClaim
                             {
                                 Id = operationClaim.Id,
                                 Name = operationClaim.Name
                             };

                return result.ToList();
            }
        }
    }
}
