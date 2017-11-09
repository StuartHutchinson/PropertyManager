using PropertyManager.Model;
using PropertyManager.View;
using System;
using System.Collections.ObjectModel;
using Xamarin.Forms;

namespace PropertyManager.ViewModel
{
    class PropertyListViewModel : BaseNavigationViewModel
    {
        public ObservableCollection<Property> Properties { get; set; }
        public Command NewPropertyCommand { get; }

        public PropertyListViewModel()
        {
            Properties = LoadProperties();
            NewPropertyCommand = new Command(NewProperty);
        }

        //private async void NewProperty(object obj) => await PushAsync(new PropertyPage(PropertyViewModel.CreateViewModel(null)){ Title = "New Property" });

        private ObservableCollection<Property> LoadProperties()
        {
            ObservableCollection<Property> properties = DependencyService.Get<IFileIO>().LoadProperties();
            if (properties == null)
                properties = new ObservableCollection<Property>();
            
            if (properties.Count == 0)
            {
                Property p = new Property();
                p.Address = new Address { Street1 = "3 Belle Isle Rd", Postcode = "LS10 2DH" };
                p.PurchaseDate = DateTime.Parse("08 Nov 2016");
                properties.Add(p);
            }            
            return properties;
        }

        internal async void NewProperty(object o)
        {
            PropertyViewModel vm = PropertyViewModel.CreateViewModel(null);
            await PushAsync(new PropertyPage(vm) { Title = "New Property" });
            Property newProperty = await vm.Retval.Task;
            if (newProperty != null)
            {
                Properties.Add(newProperty);
                OnPropertyChanged(nameof(Properties));
            }
        }

        internal async void ViewProperty(Property p)
        {
            PropertyViewModel vm = PropertyViewModel.CreateViewModel(p);
            await PushAsync(new PropertyPage(vm) { Title = p.ToString() });
            Property updated = await vm.Retval.Task;
            if (updated != null)
            {
                var i = Properties.IndexOf(p);
                Properties.Remove(p);
                Properties.Insert(i, updated);                
            }
            else
            {
                //been deleted, just remove
                Properties.Remove(p);
            }
            OnPropertyChanged(nameof(Properties));
        }
    }
}
