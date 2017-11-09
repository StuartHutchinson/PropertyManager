using PropertyManager.Model;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PropertyManager.ViewModel
{
    public class TenancyViewModel : BaseMappingViewModel<Tenancy, TenancyViewModel>
    {
        public DateTime DtStart { get; set; }
        public DateTime DtEnd { get; set; }
        public float MonthlyRent { get; set; }
        public List<Tenant> Tenants { get; set; }
        public Image Agreement { get; set; }

        public Command OKCommand { get; }

        public TenancyViewModel()
        {
            DtStart = DateTime.Today;
            DtEnd = DateTime.Today.AddYears(1);

            OKCommand = new Command(OKPressed);
        }

        protected override bool Validate()
        {
            if (MonthlyRent == 0)
            {
                DisplayValidationError("You must enter a Monthly Rent");
                return false;
            }
            return true;
        }
    }
}
