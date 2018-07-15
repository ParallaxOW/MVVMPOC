using MvvmCross.Commands;
using MvvmCross.ViewModels;

namespace Acosta.Xam.POC.ViewModels
{
    public class ProductsViewModel : MvxViewModel
    {
        private string _text = "Hello MvvmCross";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }
    }
}