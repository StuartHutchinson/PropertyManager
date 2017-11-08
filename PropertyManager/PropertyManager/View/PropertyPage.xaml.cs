using PropertyManager.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyManager.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyPage : ContentPage
    {
        public PropertyPage()
        {
            InitializeComponent();
            var vm = (PropertyViewModel)BindingContext;
            addressView.BindingContext = AddressViewModel.CreateViewModel(vm.Address);
        }
    }
}