using Android.App;
using Android.OS;
using MvvmCross.Platforms.Android.Presenters.Attributes;
using MvvmCross.Platforms.Android.Views;
using Acosta.Xam.POC.ViewModels;

namespace Acosta.Xam.POC.Droid.Views
{
    
    [Activity(Label = "ProductsView")]
    public class ProductsView : MvxActivity<ProductsViewModel>
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.products_view);
            // Create your application here
        }
    }
}