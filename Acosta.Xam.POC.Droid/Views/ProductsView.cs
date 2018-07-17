using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using Acosta.Xam.POC.ViewModels;
using MvvmCross.Droid.Support.V7.AppCompat;
using MvvmCross.Platforms.Android.Binding.Views;
using Android.Widget;
using System;

namespace Acosta.Xam.POC.Droid.Views
{
    
    [Activity(Label = "Many Products")]
    public class ProductsView : MvxAppCompatActivity<ProductsViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.products_view);
            // Create your application here
            
            
        }
    }
}