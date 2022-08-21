using System;
using MySpectrum.Core.Models;
using MySpectrum.Core.Services;
using Prism.Navigation;

namespace MySpectrumApp.ViewModels
{
    public class ProductDetailsViewModel : MySpectrumViewModelBase
    {
        private readonly INavigationService _navigationService;
        private readonly IProductsService _productsService;

        private ProductDetails _product;
        public ProductDetails Product
        {
            get => _product; 
            set => SetProperty(ref _product, value);
        }
        
        public ProductDetailsViewModel(INavigationService navigationService,
            IProductsService productsService)
        {
            _navigationService = navigationService;
            _productsService = productsService;
        }

        public override void OnNavigatedTo(INavigationParameters parameters)
        {
            var productId = parameters.GetValue<string>("id");
            LoadProduct(Guid.Parse(productId));
        }

        private async void LoadProduct(Guid productId) =>
            Product = await _productsService.GetProductDetails(productId);
    }
}