using System;
using System.Collections.Generic;
using System.Text;

namespace Acosta.Xam.POC
{
    public static class Constants
    {
        public const string BASE_ADDRESS = @"http://escmobile.com/engage/";
        public const string PRODUCT_ENDPOINT = @"engage_products.json";
        public const string EVENT_ENDPOINT = @"engage_events.json";

        public const string CONNECT_INTERNET_MSG = "Please connect to the internet.";
        public const string INITIAL_LOAD_ERROR = "We couldn't load that.";

        public const string APP_NAME = "Engage";
        public const string APP_SUB_NAME = "Proof of Concept";
        public const string ERROR_BUTTON_TEXT = "Retry";
        public const string PROGRESS_BAR_TITLE = "Syncing";
    }
}
