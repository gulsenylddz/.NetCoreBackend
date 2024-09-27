﻿using Castle.DynamicProxy;
using Core.Cross_Cutting_Concerns.Validation;
using FluentValidation;

using static Core.Utilities.Interceptors.Class1;

namespace Core.Aspect.Autofac.Validation
{
    public class ValidationAspect : MethodInterception //aspect:metodun basında
                                                       //sonunda veya metod içerisinde hata verilince
                                                       //calısacak yapıdır.
    {
        private Type _validatorType;
        public ValidationAspect(Type validatorType)
        {
            if (!typeof(IValidator).IsAssignableFrom(validatorType))
            {
                throw new System.Exception("BU BİR DOĞRULAMA SINIFI DEĞİL");
            }

            _validatorType = validatorType;
        }
        protected override void OnBefore(IInvocation invocation)
        {
            var validator = (IValidator)Activator.CreateInstance(_validatorType);
            var entityType = _validatorType.BaseType.GetGenericArguments()[0];
            var entities = invocation.Arguments.Where(t => t.GetType() == entityType);
            foreach (var entity in entities)
            {
                ValidationTool.Validate(validator, entity);
            }
        }
    }
}
