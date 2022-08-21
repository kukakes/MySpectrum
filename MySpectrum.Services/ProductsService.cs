using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySpectrum.Core.Models;
using MySpectrum.Core.Repositories;
using MySpectrum.Core.Services;

namespace MySpectrum.Services
{
    public class ProductsService : IProductsService
    {
        private readonly IProductDataStore _productDataStore;

        public ProductsService(IProductDataStore productDataStore) =>
            _productDataStore = productDataStore;


        public Task<IEnumerable<ProductSummary>> GetAllProductsSummary(string withFilter) =>
            string.IsNullOrEmpty(withFilter)
                ? _productDataStore.GetAllProductsSummary()
                : _productDataStore.GetFilteredProductsSummary(withFilter);


        public Task<ProductDetails> GetProductDetails(Guid productId) =>
            _productDataStore.GetProductDetails(productId);
    }
}