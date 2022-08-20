using Prism.Mvvm;
using Prism.Navigation;

namespace MySpectrumApp.ViewModels
{
    public class MySpectrumViewModelBase : BindableBase, INavigationAware
    {
        public virtual void OnNavigatedFrom(INavigationParameters parameters)
        {
        }

        public virtual void OnNavigatedTo(INavigationParameters parameters)
        {
        }
    }
}