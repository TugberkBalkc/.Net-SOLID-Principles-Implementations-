using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors.CastleDynamicProxy
{
    public class MethodInterception : MethodInterceptionBaseAttribute
    {   
        protected virtual void OnBefore(IInvocation İnvocation) { }
        protected virtual void OnException(Exception exception, IInvocation invocation) { }
        protected virtual void OnAfter(IInvocation invocation) { }
        protected virtual void OnSuccess(IInvocation invocation) { }


        public override void Intercept(IInvocation invocation)
        {
            var succesStatus = true;
            OnBefore(invocation);
            try
            {
                invocation.Proceed();
            }
            catch (Exception exception)
            {
                succesStatus = false;
                OnException(exception ,invocation);
                throw;
            }
            finally
            {
                if (succesStatus) OnSuccess(invocation);
            }
            OnAfter(invocation);
        }

    }

}
