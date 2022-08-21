using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using MySpectrum.Core.Models;

namespace MySpectrum.Core.Services
{
    public interface IProductsService
    {
        Task<IEnumerable<ProductSummary>> GetAllProductsSummary(string withFilter);
        Task<ProductDetails> GetProductDetails(Guid productId);
    }
}