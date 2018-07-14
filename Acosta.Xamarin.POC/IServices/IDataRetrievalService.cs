using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Acosta.Xam.POC.Core;

namespace Acosta.Xam.POC.IServices
{
    public interface IDataRetrievalService
    {
        Task<List<Product>> GetAllProducts();
        Task<List<Event>> GetAllEvents();
    }
}
