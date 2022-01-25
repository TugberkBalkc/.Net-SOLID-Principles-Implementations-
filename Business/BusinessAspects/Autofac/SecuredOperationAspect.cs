using Castle.DynamicProxy;
using Core.Aspects.Autofac.Authorization;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Core.Extensions;
using Business.Constants;

namespace Business.BusinessAspects.Autofac
{  //This Can Usable With Only JWT   
    public class SecuredOperationAspect : AuthorizationAspectBase
    {
        private string[] _roles;
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperationAspect(string roles)
        {

            _roles = roles.Split(",");
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();
        }

        protected override void OnBefore(IInvocation İnvocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRolses();
            foreach (var role in _roles)
            {
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
