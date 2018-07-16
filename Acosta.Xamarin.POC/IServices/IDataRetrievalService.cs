using System.Threading.Tasks;

using Acosta.Xam.POC.Core;

namespace Acosta.Xam.POC.IServices
{
    public interface IDataRetrievalService
    {
        Task<ProductsRetrieval> GetProductData();
        Task<EventsRetrieval> GetEventData();
    }
}
