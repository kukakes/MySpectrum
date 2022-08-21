using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using MySpectrum.Core.Models;
using MySpectrum.Core.Repositories;

namespace MySpectrum.DataStore
{
    public class ProductDataStore : IProductDataStore
    {
        private static Dictionary<Guid, ProductDetails> _sProducts;

        static ProductDataStore()
        {
            _sProducts = new Dictionary<Guid, ProductDetails>();

            var productDetails1 = new ProductDetails()
            {
                Id = Guid.NewGuid(),
                Title = "Lego Set ToyStore",
                Description = "Lego Set Toy for Kids. This is a description",
                OutofStock = false,
                Price = 45.23
            };
            
            var productDetails2 = new ProductDetails()
            {
                Id = Guid.NewGuid(),
                Title = "Super Mario Super Smash",
                Description = "Mario Bros for Kids set. Bla bla bla",
                OutofStock = false,
                Price = 34.22
            };
            
            var productDetails3 = new ProductDetails()
            {
                Id = Guid.NewGuid(),
                Title = "SnackMagic Pantry",
                Description = "Healthy food snack",
                OutofStock = true,
                Price = 50.00
            };
            
            var productDetails4 = new ProductDetails()
            {
                Id = Guid.NewGuid(),
                Title = "LCD TV",
                Description = "Samsung 45inch super bright",
                OutofStock = false,
                Price = 1199.99
            };
            
            var productDetails5 = new ProductDetails()
            {
                Id = Guid.NewGuid(),
                Title = "Apple Watch V2",
                Description = "Brand new special offer",
                OutofStock = true,
                Price = 275.13
            };

            var productDetails6 = new ProductDetails()
            {
                Id = Guid.NewGuid(),
                Title = "Bose Home Theater",
                Description = "Brand New Bose Home Theater system with surround sound",
                OutofStock = false,
                Price = 999.99
            };

            var productDetails7 = new ProductDetails()
            {
                Id = Guid.NewGuid(),
                Title = "Super Mario Race Car",
                Description = "Mario Bros for Kids set",
                OutofStock = false,
                Price = 34.22
            };

            var productDetails8 = new ProductDetails()
            {
                Id = Guid.NewGuid(),
                Title = "SnackMagic",
                Description = "Healthy food snack",
                OutofStock = true,
                Price = 50.00
            };

            var productDetails9 = new ProductDetails()
            {
                Id = Guid.NewGuid(),
                Title = "Super LED TV",
                Description = "Samsung 45inch super bright",
                OutofStock = false,
                Price = 1199.99
            };

            var productDetails10 = new ProductDetails()
            {
                Id = Guid.NewGuid(),
                Title = "Apple Watch",
                Description = "Brand new special offer",
                OutofStock = true,
                Price = 275.13
            };

            _sProducts[productDetails1.Id] = productDetails1;
            _sProducts[productDetails2.Id] = productDetails2;
            _sProducts[productDetails3.Id] = productDetails3;
            _sProducts[productDetails4.Id] = productDetails4;
            _sProducts[productDetails5.Id] = productDetails5;
            _sProducts[productDetails6.Id] = productDetails6;
            _sProducts[productDetails7.Id] = productDetails7;
            _sProducts[productDetails8.Id] = productDetails8;
            _sProducts[productDetails9.Id] = productDetails9;
            _sProducts[productDetails10.Id] = productDetails10;
        }

        public Task<IEnumerable<ProductSummary>> GetAllProductsSummary() =>
            Task.FromResult(_sProducts
                    .Select(p => new ProductSummary()
                    {
                        Id = p.Key,
                        Title = p.Value.Title,
                        Description = p.Value.Description,
                        Price = p.Value.Price
                    }));

        public Task<IEnumerable<ProductSummary>> GetFilteredProductsSummary(string titleFilter) =>
            Task.FromResult(_sProducts
                .Where(p=> p.Value.Title.ToLower().Contains(titleFilter))
                .Select(p => new ProductSummary()
                {
                    Id = p.Key,
                    Title = p.Value.Title,
                    Description = p.Value.Description,
                    Price = p.Value.Price
                }));


        public Task<ProductDetails> GetProductDetails(Guid productId) =>
            Task.FromResult(_sProducts[productId]);
    }
}