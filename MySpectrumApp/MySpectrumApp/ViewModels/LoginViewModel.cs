using System.Windows.Input;
using MySpectrum.Core.Services;
using MySpectrumApp.Views;
using Prism.Commands;
using Prism.Navigation;
using Xamarin.Forms;

namespace MySpectrumApp.ViewModels
{
    public class LoginViewModel : MySpectrumViewModelBase
    {
        private readonly ILoginService _loginService;
        private readonly INavigationService _navigationService;

        public LoginViewModel(ILoginService loginService,
            INavigationService navigationService)
        {
            _loginService = loginService;
            _navigationService = navigationService;
        }

        private bool _allowLogin;
        public bool AllowLogin
        {
            get => _allowLogin;
            set => SetProperty(ref _allowLogin, value);
        }

        private string _userName;
        public string UserName
        {
            get => _userName;
            set
            {
                SetProperty(ref _userName, value);
                UpdateLoginAvailability();
            }
        }
       
        private string _password;
        public string Password
        {
            get => _password;
            set
            {
                SetProperty(ref _password, value);
                UpdateLoginAvailability();
            }
        }
        
        private ICommand _loginCommand;
        public ICommand LoginCommand
        {
            get => _loginCommand ??=
                new DelegateCommand(PerformLogin)
                    .ObservesCanExecute(() => AllowLogin);
        }

        private void UpdateLoginAvailability() =>
            AllowLogin = !string.IsNullOrWhiteSpace(UserName) && UserName.Length > 2 &&
                         !string.IsNullOrWhiteSpace(Password) && Password.Length > 2;

        private async void PerformLogin()
        {
            AllowLogin = false;

            if (await _loginService.PerformLogin(UserName, Password))
               await _navigationService.NavigateAsync($"{nameof(NavigationPage)}/{nameof(ProductsListView)}");
            else
                AllowLogin = true;
        }
    }
}