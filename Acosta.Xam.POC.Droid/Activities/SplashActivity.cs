using MvvmCross;
using MvvmCross.Platforms.Android.Views;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

using Acosta.Xam.POC.ViewModels;


namespace Acosta.Xam.POC.Droid.Activities
{
    [Activity(Label ="Splash", MainLauncher =true)]
    public class SplashActivity : MvxActivity<SplashViewModel>
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.splash);
        }
    }
}