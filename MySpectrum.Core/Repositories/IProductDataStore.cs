using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySpectrum.Core.Models;

namespace MySpectrum.Core.Repositories
{
    public interface IProductDataStore
    {
        Task<IEnumerable<ProductSummary>> GetAllProductsSummary();
        Task<IEnumerable<ProductSummary>> GetFilteredProductsSummary(string titleFilter);
        Task<ProductDetails> GetProductDetails(Guid productId);
    }
}