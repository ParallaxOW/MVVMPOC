using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Acosta.Xam.POC.Core;

namespace Acosta.Xam.POC.IServices
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        int SaveProducts(List<Product> products);
    }
}
