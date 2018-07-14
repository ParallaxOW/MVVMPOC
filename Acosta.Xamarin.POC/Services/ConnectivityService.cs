using System;
using System.Collections.Generic;
using System.Text;
using Plugin.Connectivity;

using Acosta.Xam.POC.IServices;

namespace Acosta.Xam.POC.Services
{
    public class ConnectivityService : IConnectivityService
    {
        public bool IsConnected()
        {
            return CrossConnectivity.Current.IsConnected;
        }
    }
}
