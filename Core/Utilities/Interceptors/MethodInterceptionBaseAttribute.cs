using Castle.DynamicProxy;

namespace Core.Utilities.Interceptors
{
    [AttributeUsage(AttributeTargets.Class | AttributeTargets.Method, AllowMultiple = true, Inherited = true)]
    public abstract class MethodInterceptionBaseAttribute : Attribute, IInterceptor
    {

        //attirbute AllowMultiple = true more than 1 you can use attiribute
        //AttributeTargets.Class | AttributeTargets.Method it means you can use in classes and methods
        //when you used the inheritance it can be worked =Inherited = true
        public int Priority { get; set; }

        public virtual void Intercept(IInvocation invocation)
        {

        }
    }

}
