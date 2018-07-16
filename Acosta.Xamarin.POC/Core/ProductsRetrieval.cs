using System.Collections.Generic;

namespace Acosta.Xam.POC.Core
{
    public class ProductsRetrieval
    {
        public bool success { get; set; }
        public int code { get; set; }
        public string version { get; set; }
        public int count { get; set; }
        public List<Product> data { get; set; }
    }
}
