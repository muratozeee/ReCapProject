using Castle.DynamicProxy;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Core.Utilities.Interceptors
{


    public class AspectInterceptorSelector : IInterceptorSelector
    {
        //go to read the method's attiributes,class'attiributes 
        //then put the list
        //but it is depending on working orderby(Priority) list.
        //methodinfo is coming from reflection...

        public IInterceptor[] SelectInterceptors(Type type, MethodInfo method, IInterceptor[] interceptors)
        {
            var classAttributes = type.GetCustomAttributes<MethodInterceptionBaseAttribute>
                (true).ToList();
            var methodAttributes = type.GetMethod(method.Name)
                .GetCustomAttributes<MethodInterceptionBaseAttribute>(true);
            classAttributes.AddRange(methodAttributes);
            

            return classAttributes.OrderBy(x => x.Priority).ToArray();
        }
    }

}
