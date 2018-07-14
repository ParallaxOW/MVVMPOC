﻿using MvvmCross;
using MvvmCross.IoC;
using MvvmCross.ViewModels;

using System;
using System.Collections.Generic;
using System.Text;

using Acosta.Xam.POC.IServices;
using Acosta.Xam.POC.Services;
using Acosta.Xam.POC.ViewModels;

namespace Acosta.Xam.POC
{
    public class App : MvxApplication
    {
        public override void Initialize()
        {
            base.Initialize();

            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();

            //Mvx.RegisterType<IDataRetrievalService, DataRetrievalService>();
            //Mvx.RegisterType<IConnectivityService, ConnectivityService>();

            RegisterAppStart<SplashViewModel>();
            
        }
    }
}