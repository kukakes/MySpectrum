using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MySpectrum.Core.Models;
using MySpectrum.Core.Services;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

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

        private List<Uri> _productImages;
        public List<Uri> ProductImages
        {
            get => _productImages; 
            set => SetProperty(ref _productImages, value);
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
            LoadProductDetails(productId);
        }

        private async void LoadProductDetails(string productId)
        {
            await LoadProductImages(Guid.Parse(productId));
            await LoadProduct(Guid.Parse(productId));
        }

        private async Task LoadProductImages(Guid productId)
        {
            var imagesUrl = await LoadImagesFromServer(productId);
            ProductImages = new List<Uri>(imagesUrl
                .Select(i => new Uri(i))
                .ToList());
        }

        private async Task<List<string>> LoadImagesFromServer(Guid productId)
        {
            string img1 = "https://secure.img1-cg.wfcdn.com/im/51892760/resize-h445%5Ecompr-r85/1846/184627570/Lego+Throw+Pillow.jpg";
            string img2 = "https://www.ikea.com/us/en/images/products/bygglek-201-piece-lego-r-brick-set-mixed-colors__0915518_pe784785_s5.jpg?f=s";
            string img3 = "https://images-na.ssl-images-amazon.com/images/I/51xHtLtJUJL._SX218_BO1,204,203,200_QL40_FMwebp_.jpg";

            await Task.Delay(TimeSpan.FromMilliseconds(200));

            return new List<string>() {img1, img2, img3};
        }

        private ICommand _goBackCommand;

        public ICommand GoBackCommand =>
            _goBackCommand ??=
                new DelegateCommand(() => _navigationService.GoBackAsync());
        

        private async Task LoadProduct(Guid productId) =>
            Product = await _productsService.GetProductDetails(productId);
    }
}