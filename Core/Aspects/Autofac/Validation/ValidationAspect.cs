using Castle.DynamicProxy;
using Core.CrossCuttingConcerns.Validation;
using Core.Utilities.Interceptors;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Core.Aspects.Autofac.Validation
{
    public class ValidationAspect : MethodInterception
    {
        private Type _validatorType;
        //attributes have to use with Type
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("This is not a Validation Class ");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            //Reflection=when methods or properties are working,
            //reflection can work another somethings at the same time .
            //Activator.CreateInstance(_validatorType);=this is reflection it can be creating the instance
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            //ValidatorType which type find it then which type generic car or brand like that [0] it is first
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            //then find the paramters car or brand like that.
            //invocation=method
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
