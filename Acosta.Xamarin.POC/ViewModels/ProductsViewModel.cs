using Acosta.Xam.POC.Core;
using Acosta.Xam.POC.IServices;
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
        private readonly IEventService _eventService;
        private readonly IProductService _productService;

        //navigation service.
        private readonly IMvxNavigationService _navigationService;

        #endregion

        #region startup

        public ProductsViewModel(IEventService eventService,
                                IMvxNavigationService navigationService,
                                IProductService productService)
        {
            _eventService = eventService;
            _productService = productService;

            _navigationService = navigationService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();
            var products = _productService.GetAllProducts();
            var events = _eventService.GetAllEvents();

            Products = new MvxObservableCollection<Product>(products);
            Events = new MvxObservableCollection<Event>(events);
        }

        #endregion 

        #region bindable_properties

        private string _text = "Hello MvvmCross";
        public string Text
        {
            get { return _text; }
            set { SetProperty(ref _text, value); }
        }

        /// <summary>
        /// Product Count. Derived from Products (Products.Count)
        /// </summary>
        public int ProductCount
        {
            get => _products.Count;
        }

        /// <summary>
        /// Event Count. Derived from Events. (Events.Count)
        /// </summary>
        public int EventCount
        {
            get => _events.Count;
        }

        private MvxObservableCollection<Event> _events;
        /// <summary>
        /// Bindable List of events.
        /// </summary>
        public MvxObservableCollection<Event> Events
        {
            get => _events;
            set
            {
                _events = value;
                RaisePropertyChanged(() => Events);
                RaisePropertyChanged(() => EventCount);
            }
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

        private string _productLabelText;
        public string ProductLabelText
        {
            get => "Product Count:";
        }

        private string _eventLabelText;
        public string EventLabelText
        {
            get => "Event Count:";
        }

        #endregion
    }
}