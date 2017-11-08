using PropertyManager.View;
using PropertyManager.ViewModel;
using Xamarin.Forms;

namespace PropertyManager
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ViewProperties()
        {
            Navigation.PushAsync(new PropertyListPage { BindingContext = new PropertyListViewModel() });
        }

        private void ViewInsurance()
        {

        }

        private void ViewMortgages()
        {

        }

        private void ViewSafetyCertificates()
        {

        }

        private void ViewTenancies()
        {

        }
    }
}
