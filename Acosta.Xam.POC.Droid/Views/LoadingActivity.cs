﻿using MvvmCross;
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
using MvvmCross.Platforms.Android.Core;
using MvvmCross.Droid.Support.V7.AppCompat;
using System.Threading.Tasks;

namespace Acosta.Xam.POC.Droid.Views
{
    [Activity(MainLauncher =true, Theme = "@style/Theme.LoadingScreen")]
    public class LoadingActivity : MvxAppCompatActivity<LoadingScreenViewModel>
    {

        RelativeLayout rlProgressPane;
        RelativeLayout rlErrorPane;
        Button btnRetry;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.loading_screen);

            rlProgressPane = FindViewById<RelativeLayout>(Resource.Id.rlProgressPane);
            rlErrorPane = FindViewById<RelativeLayout>(Resource.Id.rlErrorPane);
            btnRetry = FindViewById<Button>(Resource.Id.btnRetry);
            
            btnRetry.Click += delegate { ViewModel.CheckConnectivity(); };

        }

        private void ValidateConnectivity()
        {
            if (ViewModel.IsConnected)
            {
                rlProgressPane.Visibility = ViewStates.Visible;
                rlErrorPane.Visibility = ViewStates.Invisible;
            }
            else
            {
                rlProgressPane.Visibility = ViewStates.Invisible;
                rlErrorPane.Visibility = ViewStates.Visible;
            }
        }


        private async Task LoadData()
        {
            
        }
    }
}