using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

using System;
using System.Collections.Generic;
using System.Text;

using Acosta.Xam.POC.IServices;
using Acosta.Xam.POC.Services;
using Acosta.Xam.POC.ViewModels;
using MvvmCross.Navigation;
using MvvmCross.Exceptions;

namespace Acosta.Xam.POC
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            //CreatableTypes()
            //    .EndingWith("Service")
            //    .AsInterfaces()
            //    .RegisterAsLazySingleton();

            Mvx.RegisterType<IDataRetrievalService, DataRetrievalService>();
            Mvx.RegisterType<IConnectivityService, ConnectivityService>();
            Mvx.RegisterType<IProductService, ProductService>();
            Mvx.RegisterType<IEventService, EventService>();
            
            RegisterAppStart<LoadingScreenViewModel>();
        }
    }
}
