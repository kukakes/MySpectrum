using MySpectrum.Core.Repositories;
using MySpectrum.Core.Services;
using MySpectrum.DataStore;
using MySpectrum.Services;
using MySpectrumApp.ViewModels;
using MySpectrumApp.Views;
using Prism;
using Prism.Ioc;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]

namespace MySpectrumApp
{
    public partial class App
    {
        public App(IPlatformInitializer platformInitializer)
            :base(platformInitializer)
        {
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }

        protected override async void OnInitialized()
        {
            InitializeComponent(); 

            //await NavigationService.NavigateAsync($"{nameof(LoginView)}");
            await NavigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(ProductsListView)}");
        }
        
        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.Register<ILoginService, LoginService>();
            containerRegistry.Register<IProductsService, ProductsService>();
            containerRegistry.Register<IProductDataStore, ProductDataStore>();
            
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<LoginView, LoginViewModel>();
            containerRegistry.RegisterForNavigation<ProductsListView, ProductsListViewModel>();
            containerRegistry.RegisterForNavigation<ProductDetailsView, ProductDetailsViewModel>();
        }
    }
}