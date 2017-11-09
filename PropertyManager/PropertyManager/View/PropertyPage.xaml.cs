using PropertyManager.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyManager.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyPage : ContentPage
    {
        internal PropertyPage(PropertyViewModel vm)
        {
            InitializeComponent();
            BindingContext = vm;
            AddressViewModel avm = AddressViewModel.CreateViewModel(vm.Address);
            addressView.BindingContext = avm;
            vm.AddressViewModel = avm;
        }
    }
}