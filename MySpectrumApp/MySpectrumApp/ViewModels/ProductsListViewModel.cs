using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;
using System.Windows.Input;
using MySpectrum.Core.Models;
using MySpectrum.Core.Services;
using MySpectrumApp.Views;
using Prism.Commands;
using Prism.Navigation;

namespace MySpectrumApp.ViewModels
{
    public class ProductsListViewModel : MySpectrumViewModelBase
    {
        private readonly IProductsService _productsService;
        private readonly INavigationService _navigationService;

        private ObservableCollection<ProductSummary> _products;
        public ObservableCollection<ProductSummary> Products
        {
            get => _products;
            set => SetProperty(ref _products, value);
        }
        
        public ProductsListViewModel(IProductsService productsService,
            INavigationService navigationService)
        {
            _productsService = productsService;
            _navigationService = navigationService;
        }

        private string _searchFilter;
        public string SearchFilter
        {
            get => _searchFilter;
            set => SetProperty(ref _searchFilter, value);
        }

        private bool _ascendingSortOrder = false;
        public bool AscendingSortOrder
        {
            get => _ascendingSortOrder; 
            set => SetProperty(ref _ascendingSortOrder, value);
        }

        private ProductSummary _selectedProduct;
        public ProductSummary SelectedProduct
        {
            get => _selectedProduct; 
            set => SetProperty(ref _selectedProduct, value);
        }

        private ICommand _productSelectedCommand;
        public ICommand ProductSelectedCommand =>
            _productSelectedCommand ??=
                new DelegateCommand<ProductSummary> (async(e) =>
                {
                    SelectedProduct = e;
                    await ShowSelectedProductDetails();
                });


        private ICommand _changeSortOrderCommand;
        public ICommand ChangeSortOrderCommand =>
            _changeSortOrderCommand ??=
                new DelegateCommand(ChangeSortOrder);

        private ICommand _applySearchFilterCommand;
        public ICommand ApplySearchFilterCommand =>
            _applySearchFilterCommand ??=
                new DelegateCommand<string>(async(e) =>
                {
                    if (SearchFilter == e)
                        return;

                    SearchFilter = e;
                    await LoadProducts();
                });
        
        public override void OnNavigatedTo(INavigationParameters parameters) =>
            LoadProducts();

        private void ChangeSortOrder()
        {
            AscendingSortOrder = !AscendingSortOrder;
            ApplySort();
        }
        
        private async Task LoadProducts()
        {
            Products?.Clear();
            
            var allProducts = await _productsService.GetAllProductsSummary(SearchFilter?.ToLower());
            Products = new ObservableCollection<ProductSummary>(allProducts?? Enumerable.Empty<ProductSummary>());
            
            ApplySort();
        }

        private void ApplySort()
        {
            var sortedProducts = AscendingSortOrder
                ? Products?.OrderBy(p => p.Title).ToList()
                : Products?.OrderByDescending(p => p.Title).ToList();
            
            //Products?.Clear();
            Products = new ObservableCollection<ProductSummary>(sortedProducts);
        }

        // private async void ShowSelectedProductDetails()
        // {
        //     var navParams = new NavigationParameters()
        //     {
        //         {"id", SelectedProduct.Id}
        //     };
        //     
        //     await _navigationService.NavigateAsync($"{nameof(ProductDetailsView)}", navParams);
        // }
        private async Task ShowSelectedProductDetails() =>
            await _navigationService.NavigateAsync(new Uri($"{nameof(ProductDetailsView)}?id={SelectedProduct.Id}", 
                UriKind.Relative), useModalNavigation: false);
    }
}