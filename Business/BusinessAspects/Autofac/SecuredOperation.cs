using Business.Constants;
using Castle.DynamicProxy;
using Core.Extensions;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.AspNetCore.Http;
using Microsoft.Extensions.DependencyInjection;

namespace Business.BusinessAspects.Autofac
{
    //JWT is Http request and AOP
    public class SecuredOperation : MethodInterception
    {
        private string[] _roles;
        //when we request the jwt, it will be created Httpcontext
        private IHttpContextAccessor _httpContextAccessor;

        public SecuredOperation(string roles)
        {
            //Split is seperate firstly then sending the array.
            _roles = roles.Split(',');
            //ServiceTool we can read the infrastructure
            _httpContextAccessor = ServiceTool.ServiceProvider.GetService<IHttpContextAccessor>();

        }

        //onBefore means it has to work before method.
        protected override void OnBefore(IInvocation invocation)
        {
            var roleClaims = _httpContextAccessor.HttpContext.User.ClaimRoles();
            //travel the all roles with foreach
            foreach (var role in _roles)
            {
                //if it includes the role,it can return.
                if (roleClaims.Contains(role))
                {
                    return;
                }
            }
            //there is not in here,then it will throw exception.
            throw new Exception(Messages.AuthorizationDenied);
        }
    }
}
