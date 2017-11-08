using PropertyManager.ViewModel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

        private void NewProperty(PropertyListViewModel obj)
        {
            throw new NotImplementedException();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            var vm = (PropertyListViewModel)BindingContext;
            vm.ViewProperty();
        }
    }
}