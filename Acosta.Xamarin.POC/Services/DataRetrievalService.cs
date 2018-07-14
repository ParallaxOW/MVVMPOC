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

        public async Task<List<Event>> GetAllEvents()
        {
            List<Event> result = new List<Event>();
            
            Thread.Sleep(5000);
            //var response = await client.GetStringAsync(Constants.EVENT_ENDPOINT);
            //var result = JsonConvert.DeserializeObject<List<Event>>(response);
            return result;
        }

        public async Task<List<Product>> GetAllProducts()
        {
            List<Product> result = BuildTestProducts();
            Thread.Sleep(5000);
            //var response = await client.GetStringAsync(Constants.PRODUCT_ENDPOINT);
            //var result = JsonConvert.DeserializeObject<List<Product>>(response);
            return result;
        }

        private List<Product> BuildTestProducts()
        {
            List<Product> result = new List<Product>();

            for (int i = 0; i >= 50; i++)
            {
                string name = string.Format("Product-{0}", i);
                result.Add(new Product() { Id = i, Name = name });
            }

            return result;
        }

        private List<Event> BuildTestEvents()
        {
            List<Event> result = new List<Event>();

            for (int i = 0; i >= 50; i++)
            {
                string name = string.Format("Event-{0}", i);
                result.Add(new Event() { Id = i, Name = name });
            }

            return result;
        }
    }
}
