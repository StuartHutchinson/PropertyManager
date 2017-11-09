using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PropertyManager.ViewModel
{
    public class BaseViewModel : INotifyPropertyChanged 
    {
        public event PropertyChangedEventHandler PropertyChanged;

        protected void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        protected async void DisplayAlert(string title, string message, string cancel)
        {
            await Application.Current?.MainPage?.DisplayAlert(title, message, cancel);
        }

        protected async Task<bool> DisplayAlert(string title, string message, string accept, string cancel)
        {
            var retval = await Application.Current?.MainPage?.DisplayAlert(title, message, accept, cancel);
            return retval;
        }
    }
}
