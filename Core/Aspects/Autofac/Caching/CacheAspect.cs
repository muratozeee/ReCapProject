using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Caching;
using Core.Utilities.Interceptors;
using Core.Utilities.IoC;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Caching
{
    public class CacheAspect : MethodInterception
    {
        private int _duration;
        private ICacheManager _cacheManager;

        //it is holding data 60 min.
        public CacheAspect(int duration = 60)
        {
            _duration = duration;
            //ı can use for which type of the methods and service. Iam using for cachingmanager
            _cacheManager = ServiceTool.ServiceProvider.GetService<ICacheManager>();
            //if we use the redis dont touch this code.
         
        }
        //invocation = methods to use Onbefore,Onsuccess,OnAfter
        public override void Intercept(IInvocation invocation)
        {
            //when ı wanted the key it should be have methodName
            //Reflection Type=take the namespace.
            //ReflectionType.FullName = namespace(Core.Aspects.Autofac.Caching) + fullname(CacheAspect : MethodInterception)
            //invocation.Method.Name (getall) and they are key all thing sum in methodName


            var methodName = string.Format($"{invocation.Method.ReflectedType.FullName}.{invocation.Method.Name}");
            //arguments = parameters 
            var arguments = invocation.Arguments.ToList();
            //if key dont have then it has a null
            //arguments.Select(x => x?.ToString() ?? "<Null>"))})"; if it is string add the as a string,
            //if it is false add the Null, then list them
            var key = $"{methodName}({string.Join(",", arguments.Select(x => x?.ToString() ?? "<Null>"))})";
            //Let's check the memory it has same key or no
            if (_cacheManager.IsAdd(key))
            {
                //if key has same with cache, return the value
                invocation.ReturnValue = _cacheManager.Get(key);
                return;
            }
            //if it doesnt have the same key in cache, continue and cache take the this key 
            invocation.Proceed();
            _cacheManager.Add(key, invocation.ReturnValue, _duration);
        }
    }
}
