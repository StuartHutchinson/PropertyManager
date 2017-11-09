using PropertyManager.View;
using PropertyManager.ViewModel;
using System;
using Xamarin.Forms;

namespace PropertyManager
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
        }

        private void ViewProperties(object sender, EventArgs e)
        {
            Navigation.PushAsync(new PropertyListPage { BindingContext = new PropertyListViewModel() });
        }

        private void ViewInsurance(object sender, EventArgs e)
        {

        }

        private void ViewMortgages(object sender, EventArgs e)
        {

        }

        private void ViewSafetyCertificates(object sender, EventArgs e)
        {

        }

        private void ViewTenancies(object sender, EventArgs e)
        {

        }
    }
}
