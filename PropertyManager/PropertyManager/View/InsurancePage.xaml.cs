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
    public partial class InsurancePage : ContentPage
    {
        public InsurancePage()
        {
            InitializeComponent();
        }

        internal InsurancePage(InsuranceViewModel ivm) : this()
        {
            BindingContext = ivm;
        }
    }
}