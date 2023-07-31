using System.Transactions;
using Castle.DynamicProxy;
using Core.Utilities.Interceptors;

namespace Core.Aspects.Autofac.Transaction
{
    public class TransactionScopeAspect : MethodInterception
    {
        //method
        public override void Intercept(IInvocation invocation)
        {

            using (TransactionScope transactionScope = new TransactionScope())
            {
                //working method
                try
                {
                    invocation.Proceed();
                    transactionScope.Complete();
                }
                //if something wrong
                catch (System.Exception e)
                {
                    //retrieval the method.
                    transactionScope.Dispose();
                    throw;
                }
            }
        }
    }
}