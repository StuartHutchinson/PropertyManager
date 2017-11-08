using PropertyManager.Model;
using PropertyManager.View;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PropertyManager.ViewModel
{
    class PropertyListViewModel : BaseNavigationViewModel
    {
        public List<Property> Properties { get; }
        public Command NewPropertyCommand { get; }

        public PropertyListViewModel()
        {
            Properties = LoadProperties();
            NewPropertyCommand = new Command(NewProperty);
        }

        private async void NewProperty(object obj) => await PushAsync(new PropertyPage { BindingContext = PropertyViewModel.CreateViewModel(null), Title = "New Property" });

        private List<Property> LoadProperties()
        {
            List<Property> properties = new List<Property>();
            //todo - load from file
            return properties;
        }

        internal async void ViewProperty()
        {
            Property p = null;
            await PushAsync(new PropertyPage { BindingContext = PropertyViewModel.CreateViewModel(p), Title = p.GetName() });
        }
    }
}
