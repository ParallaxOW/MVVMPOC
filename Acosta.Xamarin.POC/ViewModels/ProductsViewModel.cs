using Acosta.Xam.POC.Core;
using Acosta.Xam.POC.IServices;
using MvvmCross;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading.Tasks;

namespace Acosta.Xam.POC.ViewModels
{
    public class ProductsViewModel : MvxViewModel
    {
        #region private_variables
        //object services
        private readonly IProductService _productService;

        #endregion

        #region startup

        public ProductsViewModel(IProductService productService)
        {
            _productService = productService;

        }

        public override async Task Initialize()
        {
            var products = _productService.GetAllProducts();
            Products = new MvxObservableCollection<Product>(products);

        }

        #endregion 

        #region bindable_properties


        /// <summary>
        /// Product Count. Derived from Products (Products.Count)
        /// </summary>
        public int ProductCount
        {
            get => _products.Count;
        }

        private MvxObservableCollection<Product> _products;
        /// <summary>
        /// Bindable list of Products
        /// </summary>
        public MvxObservableCollection<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                RaisePropertyChanged(() => Products);
                RaisePropertyChanged(() => ProductCount);
            }
        }

        #endregion
    }
}