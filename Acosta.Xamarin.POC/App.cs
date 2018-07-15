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

            RegisterCustomAppStart<CustomMvxAppStart<LoadingScreenViewModel>>();
        }
    }

    public class CustomMvxAppStart<TViewModel> : MvxAppStart<TViewModel> where TViewModel : IMvxViewModel
    {
        public CustomMvxAppStart(IMvxApplication application, IMvxNavigationService navigationService) : base(application, navigationService)
        {

        }

        protected override void NavigateToFirstViewModel(object hint = null)
        {
            try
            {
                NavigationService.Navigate<TViewModel>();
            }
            catch (Exception exc)
            {
                throw exc.MvxWrap("Problem navigating to ViewModel {0}", typeof(TViewModel).Name);  
            }
        }
    }
}
