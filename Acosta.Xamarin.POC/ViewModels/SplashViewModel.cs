using MvvmCross.ViewModels;

using System;
using System.Collections.Generic;
using System.Text;

using Acosta.Xam.POC.IServices;
using Acosta.Xam.POC.Services;
using Acosta.Xam.POC.Core;
using System.Threading.Tasks;

namespace Acosta.Xam.POC.ViewModels
{
    public class SplashViewModel : MvxViewModel
    {
        private IConnectivityService _connectivityService;
        private IDataRetrievalService _dataRetrievalService;
        private IProductService _productService;
        private IEventService _eventService;

        public SplashViewModel(IConnectivityService connectivityService,
                                IDataRetrievalService dataRetrievalService,
                                IEventService eventService,
                                IProductService productService)
        {
            _connectivityService = connectivityService;
            _dataRetrievalService = dataRetrievalService;
            _eventService = eventService;
            _productService = productService;
        }

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

        public override async Task Initialize()
        {
            await base.Initialize();

            this.TitleText = "Engage";
            this.SubTitleText = "Proof of Concept";
        }

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
    }
}