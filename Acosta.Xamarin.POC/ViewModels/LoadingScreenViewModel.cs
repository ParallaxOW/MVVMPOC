using MvvmCross.ViewModels;
using MvvmCross.Navigation;

using System;
using System.Collections.Generic;
using System.Threading.Tasks;

using Acosta.Xam.POC.IServices;
using Acosta.Xam.POC.Services;
using Acosta.Xam.POC.Core;


namespace Acosta.Xam.POC.ViewModels
{
    public class LoadingScreenViewModel : MvxViewModel
    {

        #region private_variables
        //object services
        private readonly IConnectivityService _connectivityService;
        private readonly IDataRetrievalService _dataRetrievalService;
        private readonly IEventService _eventService;
        private readonly IProductService _productService;

        //navigation service.
        private readonly IMvxNavigationService _navigationService;

        #endregion

        #region startup

        public LoadingScreenViewModel(IConnectivityService connectivityService,
                                IDataRetrievalService dataRetrievalService,
                                IEventService eventService,
                                IMvxNavigationService navigationService,
                                IProductService productService)
        {
            _connectivityService = connectivityService;
            _dataRetrievalService = dataRetrievalService;
            _eventService = eventService;
            _productService = productService;

            _navigationService = navigationService;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            this.TitleText = Constants.APP_NAME;
            this.SubTitleText = Constants.APP_SUB_NAME;
            this.ErrorButtonText = Constants.ERROR_BUTTON_TEXT;
            this.ProgressBarTitle = Constants.PROGRESS_BAR_TITLE;

            IsConnected = _connectivityService.IsConnected();

            this.ErrorMessage = (!IsConnected ? Constants.CONNECT_INTERNET_MSG : String.Empty);

            Products = ProductService.GetAllProducts();
            Events = EventService.GetAllEvents();

            ProductsLoaded = (ProductCount > 0);
            EventsLoaded = (EventCount > 0);

            //if we're connected lets check for data
            if (IsConnected)
            {
                //if either the products or events aren't loaded, lets go get them.
                if (!ProductsLoaded || !EventsLoaded)
                {
                    //something's not loaded, lets go get it.  
                    //navigation will happen at the bottom of this method.
                    await LoadData();
                }
                else if (ProductsLoaded && EventsLoaded)
                {
                    //everything's loaded, lets ski-daddle!
                    await NavigateToProductsScreen();
                }
            }
        }

        //public override void ViewAppeared()
        //{
        //    //base.ViewAppeared();

        //    this.ErrorMessage = (!IsConnected ? Constants.CONNECT_INTERNET_MSG : String.Empty);

        //    Products = ProductService.GetAllProducts();
        //    Events = EventService.GetAllEvents();

        //    ProductsLoaded = (ProductCount > 0);
        //    EventsLoaded = (EventCount > 0);

        //    //if we're connected lets check for data
        //    if (IsConnected)
        //    {
        //        //if either the products or events aren't loaded, lets go get them.
        //        if (!ProductsLoaded || !EventsLoaded)
        //        {
        //            //something's not loaded, lets go get it.  
        //            //navigation will happen at the bottom of this method.
        //            Task.Run(async () => { await LoadData(); });
        //        }
        //        else if (ProductsLoaded && EventsLoaded)
        //        {
        //            //everything's loaded, lets ski-daddle!
        //            Task.Run(async () => { await NavigateToProductsScreen(); });
        //        }
        //    }
        //}

        #endregion

        #region exposed_services
        /// <summary>
        /// Resolved instance of the Product Service
        /// </summary>
        public IProductService ProductService
        {
            get => _productService;
        }

        /// <summary>
        /// DI Resolved Instance of the Event Service
        /// </summary>
        public IEventService EventService
        {
            get => _eventService;
        }

        /// <summary>
        /// DI Resolved Instance of the DataRetrieval Service.
        /// </summary>
        public IDataRetrievalService DataRetrievalService
        {
            get => _dataRetrievalService;
        }
        #endregion

        #region navigation_methods

        public override void Prepare()
        {
            base.Prepare();
        }

        public async Task NavigateToProductsScreen()
        {
            await _navigationService.Navigate<ProductsViewModel>();
        }

        #endregion

        #region bindable_properties

        private bool _isConnected;
        /// <summary>
        /// Connected to the internet.
        /// </summary>
        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                RaisePropertyChanged(() => IsConnected);
            }
        }

        private bool _isNotError;
        /// <summary>
        /// used in REVERSE logic in ShowErrorPane (if not IsConnected or if not IsNotError).
        /// Set this to FALSE if there's an error.  True means we're all good.
        /// </summary>
        public bool IsNotError
        {
            get => _isNotError;
            set
            {
                _isNotError = value;
                //if we're in error, lets hide the progress pane.
                if (!_isNotError) _isConnected = false;

                RaisePropertyChanged(() => IsNotError);
                RaisePropertyChanged(() => ShowErrorPane);
                RaisePropertyChanged(() => ShowProgressPane);
            }
        }

        /// <summary>
        /// Bind to Visibility of the Error Pane
        /// </summary>
        public bool ShowErrorPane
        {
            get => (!_isConnected || !_isNotError);
        }

        public bool ShowProgressPane
        {
            get => _isConnected;
        }

        private string _errorMessage;
        /// <summary>
        /// Bind to Message text in error pane.
        /// </summary>
        public string ErrorMessage
        {
            get => _errorMessage;
            set
            {
                _errorMessage = value;
                RaisePropertyChanged(() => ErrorMessage);
            }
        }

        private string _errorButtonText;
        /// <summary>
        /// Bind to button text in error pane.
        /// </summary>
        public string ErrorButtonText
        {
            get => _errorButtonText;
            set
            {
                _errorButtonText = value;
                RaisePropertyChanged(() => ErrorButtonText);
            }
        }

        private string _titleText;
        /// <summary>
        /// Bind to Title Text.
        /// </summary>
        public string TitleText
        {
            get => _titleText;
            set
            {
                _titleText = value;
                RaisePropertyChanged(() => TitleText);
            }
        }

        private string _subTitleText;
        /// <summary>
        /// Bind to SubTitle Text.
        /// </summary>
        public string SubTitleText
        {
            get => _subTitleText;
            set
            {
                _subTitleText = value;
                RaisePropertyChanged(() => SubTitleText);
            }
        }

        private string _progressBarTitle;
        /// <summary>
        /// Bind to Progress Bar Label.
        /// </summary>
        public string ProgressBarTitle
        {
            get => _progressBarTitle;
            set
            {
                _progressBarTitle = value;
                RaisePropertyChanged(() => ProgressBarTitle);
            }
        }

        private int _progressBarProgress;
        /// <summary>
        /// Bind to ProgressBar.Progress.
        /// </summary>
        public int ProgressBarProgress
        {
            get => _progressBarProgress;
            set
            {
                _progressBarProgress = value;
                RaisePropertyChanged(() => ProgressBarProgress);
            }
        }

        private List<Product> _products;
        /// <summary>
        /// List of products.
        /// </summary>
        public List<Product> Products
        {
            get => _products;
            set
            {
                _products = value;
                RaisePropertyChanged(() => Products);
                RaisePropertyChanged(() => ProductCount);
            }
        }

        /// <summary>
        /// Count of products.  Derived from Products.
        /// </summary>
        public int ProductCount
        {
            get => _products.Count;
        }

        private bool _productsLoaded;
        /// <summary>
        /// Are the products loaded?  We're not deriving it in case there are no products available for download.
        /// </summary>
        public bool ProductsLoaded
        {
            get => _productsLoaded;
            set
            {
                _productsLoaded = value;
                RaisePropertyChanged(() => ProductsLoaded);
            }
        }

        private bool _eventsLoaded;
        /// <summary>
        /// Are Events loaded?  We're not deriving this in case there are no events available for download.
        /// </summary>
        public bool EventsLoaded
        {
            get => _eventsLoaded;
            set
            {
                _eventsLoaded = value;
                RaisePropertyChanged(() => EventsLoaded);
            }
        }

        private List<Event> _events;
        /// <summary>
        /// List of Events.
        /// </summary>
        public List<Event> Events
        {
            get => _events;
            set
            {
                _events = value;
                RaisePropertyChanged(() => Events);
                RaisePropertyChanged(() => EventCount);
            }
        }

        /// <summary>
        /// Count of events. Derived from Events.
        /// </summary>
        public int EventCount
        {
            get => _events.Count;
        }
        
        #endregion

        #region bindable_methods

        /// <summary>
        /// Bind to click event of Retry Button
        /// </summary>
        public void CheckConnectivity()
        {
            IsConnected = _connectivityService.IsConnected();
            Task.Run(async () => { await LoadData(); });
        }

        #endregion
        
        #region helpers

        /// <summary>
        /// Loads any data that's not already loaded based on ProductsLoaded and EventsLoaded.
        /// If either fails, it sets the IsNotError to false, and exits.
        /// Navigates to Products datamodel on successful completion.
        /// </summary>
        /// <returns></returns>
        private async Task LoadData()
        {
            if (!ProductsLoaded)
            {
                try
                {
                    if (Products == null) Products = new List<Product>();
                    
                    var retrievedProducts = await DataRetrievalService.GetAllProducts();
                    ProgressBarProgress = 15;

                    //uncomment to pitch error here
                    //int i = 0;
                    //int text = 15 / i;

                    var numProducts = ProductService.SaveProducts(retrievedProducts);
                    ProgressBarProgress = 35;

                    Products = ProductService.GetAllProducts();
                    ProgressBarProgress = 50;

                    ProductsLoaded = true;
                }
                catch (Exception exc)
                {
                    //if we're in error, set the message, isnoterror and bail, we can't do any more.
                    
                    ErrorMessage = "We couldn't load that.";
                    IsNotError = false;
                    return;
                }
            }

            if (!EventsLoaded)
            {
                try
                {
                    if (Events == null) Events = new List<Event>();

                    var retrievedEvents = await DataRetrievalService.GetAllEvents();
                    ProgressBarProgress = 65;

                    //uncomment to pitch error here
                    //int i = 0;
                    //int text = 15 / i;

                    var numEvents = EventService.SaveEvents(retrievedEvents);
                    ProgressBarProgress = 80;

                    Events = EventService.GetAllEvents();
                    ProgressBarProgress = 100;

                    EventsLoaded = true;
                }
                catch(Exception exc)
                {
                    //if we're in error, set the message, isnoterror and bail, we can't do any more.
                    ErrorMessage = "We couldn't load that.";
                    IsNotError = false;
                    return;
                }
            }

            //if we get here, everything loaded successfully, let's navigate.
            await NavigateToProductsScreen();
        }

        #endregion

    }
}