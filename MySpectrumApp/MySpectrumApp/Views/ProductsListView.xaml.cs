using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace MySpectrumApp.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class ProductsListView : ContentPage
    {
        public ProductsListView()
        {
            InitializeComponent();
        }

        void search_Unfocused(System.Object sender, Xamarin.Forms.FocusEventArgs e)
        {
            if(sender is SearchBar searchBar &&
               string.IsNullOrEmpty(searchBar.Text))
            {
                searchBar.SearchCommand.Execute(string.Empty);
            }
        }
    }
}