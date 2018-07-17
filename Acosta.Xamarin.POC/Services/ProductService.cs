using Realms;

using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

using Acosta.Xam.POC.Core;
using Acosta.Xam.POC.IServices;
using System.Linq;

namespace Acosta.Xam.POC.Services
{
    public class ProductService : IProductService
    {
        private Realm _realm;

        public ProductService()
        {
            _realm = Realm.GetInstance();
        }

        public List<Product> GetAllProducts() => _realm.All<Product>().ToList();

        public int SaveProduct(Product product)
        {
            try
            {
                _realm.Write(() => _realm.Add(product));
                return 1;
            }
            catch
            {
                return 0;
            }
        }

        public int SaveProducts(List<Product> products)
        {
            products.ForEach(x => {
                _realm.Write(() => _realm.Add(x));
            });

            return products.Count;
        }
    }
}
