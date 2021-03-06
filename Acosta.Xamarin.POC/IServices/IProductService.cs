﻿using System.Collections.Generic;
using Acosta.Xam.POC.Core;

namespace Acosta.Xam.POC.IServices
{
    public interface IProductService
    {
        List<Product> GetAllProducts();
        int SaveProduct(Product product);
        int SaveProducts(List<Product> products);
    }
}
