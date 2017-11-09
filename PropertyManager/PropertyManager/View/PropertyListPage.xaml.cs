using PropertyManager.Model;
using PropertyManager.ViewModel;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace PropertyManager.View
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class PropertyListPage : ContentPage
    {
        public PropertyListPage()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            ListView listView = (ListView)sender;
            if (listView.SelectedItem is null)
                return;
            var vm = (PropertyListViewModel)BindingContext;            
            vm.ViewProperty((Property)listView.SelectedItem);
            listView.SelectedItem = null;
        }

        protected override void OnDisappearing()
        {
            var vm = (PropertyListViewModel)BindingContext;
            DependencyService.Get<IFileIO>().SaveProperties(vm.Properties);
        }
    }
}