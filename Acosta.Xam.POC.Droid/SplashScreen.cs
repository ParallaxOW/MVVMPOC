using MvvmCross.Droid.Support.V7.AppCompat;

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

namespace Acosta.Xam.POC.Droid
{
    [Activity(MainLauncher=true,Theme = "@style/Theme.LoadingScreen", NoHistory = true)]
    public class SplashScreen : MvxSplashScreenAppCompatActivity
    {
        public SplashScreen() : base(Resource.Layout.splashscreen) { }
        //protected override void OnCreate(Bundle savedInstanceState)
        //{
        //    base.OnCreate(savedInstanceState);

        //    // Create your application here
        //}
    }
}