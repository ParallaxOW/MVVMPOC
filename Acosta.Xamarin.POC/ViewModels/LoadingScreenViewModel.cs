using MvvmCross.ViewModels;

using System;
using System.Collections.Generic;
using System.Text;

using Acosta.Xam.POC.IServices;
using Acosta.Xam.POC.Services;
using Acosta.Xam.POC.Core;
using System.Threading.Tasks;
using MvvmCross.UI;

namespace Acosta.Xam.POC.ViewModels
{
    public class LoadingScreenViewModel : MvxViewModel
    {
        private readonly IConnectivityService _connectivityService;
        private readonly IDataRetrievalService _dataRetrievalService;
        private readonly IProductService _productService;
        private readonly IEventService _eventService;

        public LoadingScreenViewModel(IConnectivityService connectivityService,
                                IDataRetrievalService dataRetrievalService,
                                IEventService eventService,
                                IProductService productService)
        {
            _connectivityService = connectivityService;
            _dataRetrievalService = dataRetrievalService;
            _eventService = eventService;
            _productService = productService;
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
        }

        #region exposed_services
        public IProductService ProductService
        {
            get => _productService;
        }

        public IEventService EventService
        {
            get => _eventService;
        }

        public IDataRetrievalService DataRetrievalService
        {
            get => _dataRetrievalService;
        }
        #endregion

        private bool _isConnected;
        public bool IsConnected
        {
            get => _isConnected;
            set
            {
                _isConnected = value;
                RaisePropertyChanged(() => IsConnected);
            }
        }

        private string _errorMessage;
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

        public int ProductCount
        {
            get => _products.Count;
        }

        private bool _productsLoaded;
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

        public int EventCount
        {
            get => _events.Count;
        }

        public async Task LoadData()
        {
            if (Products == null) Products = new List<Product>();

            Products = await DataRetrievalService.GetAllProducts();

            if (Events == null) Events = new List<Event>();
                
        }

        public void CheckConnectivity()
        {
            IsConnected = _connectivityService.IsConnected();
        }

    }
}