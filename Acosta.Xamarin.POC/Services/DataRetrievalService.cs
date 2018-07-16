using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Text;
using System.Threading;



using Acosta.Xam.POC.IServices;
using Acosta.Xam.POC.Core;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace Acosta.Xam.POC.Services
{
    public class DataRetrievalService : IDataRetrievalService
    {
        private HttpClient client;

        public DataRetrievalService()
        {
            client = new HttpClient();
            client.BaseAddress = new Uri(Constants.BASE_ADDRESS);
        }

        public async Task<EventsRetrieval> GetEventData()
        {
            var response = await client.GetAsync(Constants.EVENT_ENDPOINT);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<EventsRetrieval>(responseString);
            return result;
        }

        public async Task<ProductsRetrieval> GetProductData()
        {
            var response = await client.GetAsync(Constants.PRODUCT_ENDPOINT);
            var responseString = await response.Content.ReadAsStringAsync();
            var result = JsonConvert.DeserializeObject<ProductsRetrieval>(responseString);
            return result;
        }
    }
}
