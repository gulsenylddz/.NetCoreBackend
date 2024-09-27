using Autofac;
using Autofac.Extras.DynamicProxy;
using Business.Abstract;
using Business.Concrete;
using Castle.DynamicProxy;
using DataAccess.Abstract;
using DataAccess.Concrete.EntityFramework;
using System;
using System.Collections.Generic;
using System.Text;
using static Core.Utilities.Interceptors.Class1;

namespace Business.Constants.DependencyResolvers.Autofac //bağımlılıkları belirlediğimiz sınıf
{
    public class AutofacBusinessModule:Module
    {
        protected override void Load(ContainerBuilder builder)
        {
            builder.RegisterType<ProductManager>().As<IProductService>().SingleInstance();
            //kodun anlamı senden ıproduct service istenilirse ona productmanager instance'ı ver demek. 
            //veri tutmadığını sadece veriyi taşıdığını bildiğimiz için singleinstance() kullan.
            //bu işlem bizi sürekli new'leme yapmaktan kurtarır.

            builder.RegisterType<EfProductDal>().As<IProductDal>().SingleInstance();


            var assembly = System.Reflection.Assembly.GetExecutingAssembly();

            builder.RegisterAssemblyTypes(assembly).AsImplementedInterfaces()
                .EnableInterfaceInterceptors(new ProxyGenerationOptions()
                {
                    Selector = new AspectInterceptorSelector()
                }).SingleInstance();
        }
    }
}
