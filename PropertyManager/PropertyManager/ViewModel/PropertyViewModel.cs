using PropertyManager.Model;
using PropertyManager.View;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PropertyManager.ViewModel
{
    internal class PropertyViewModel : BaseMappingViewModel<Property, PropertyViewModel>
    {
        public Address Address { get; set; }
        public DateTime PurchaseDate { get; set; }
        public int PurchasePrice { get; set; }
        public InsurancePolicy CurrentInsurance { get; set; }
        public Mortgage CurrentMortgage { get; set; }
        public List<InsurancePolicy> PreviousInsurances { get; set; }
        public List<Mortgage> PreviousMortgages { get; set; }
        public List<SafetyCertificate> SafetyCertificates { get; set; }
        public Tenancy CurrentTenancy { get; set; }
        public List<Tenancy> PreviousTenancies { get; set; }

        private bool existingProperty;
        public bool IsExistingProperty { get { return existingProperty; } }

        //public TaskCompletionSource<Property> retval = new TaskCompletionSource<Property>();
        public AddressViewModel AddressViewModel { get; set; }

        #region summary strings
        public string TenancySummary
        {
            get
            {
                var summary = "No current tenancy";
                if (CurrentTenancy != null)
                {
                    var dtEnd = CurrentTenancy.DtEnd;
                    summary = "Ends on " + dtEnd.ToString("d");
                }
                return summary;
            }
        }
        public string InsuranceSummary
        {
            get
            {
                var summary = "No current insurance";
                if (CurrentInsurance != null)
                {
                    var dtExpiry = CurrentInsurance.DtEnd;
                    summary = "Expires on " + dtExpiry.ToString("d");
                }
                return summary;
            }
        }
        public string MortgageSummary
        {
            get
            {
                var summary = "No current mortgage";
                if (CurrentMortgage != null)
                {
                    var dtExpiry = CurrentMortgage.DtFixedRateExpiry;
                    summary = "Fixed rate expires on " + dtExpiry.ToString("d");
                }
                return summary;
            }
        }
        public string SafetyCertificateSummary
        {
            get
            {
                var summary = "No current safety certificates";
                var gas = SafetyCertificate.GetLatestGas(SafetyCertificates);
                var elec = SafetyCertificate.GetLatestElectrical(SafetyCertificates);
                if (gas != null)
                {
                    summary = "Gas due on " + gas.DtNextDue.ToString("d");
                    if (elec != null)
                    {
                        summary += ". Electrical due on " + elec.DtNextDue.ToString("d");
                    }
                    else
                    {
                        summary += ". No current electrical certificate";
                    }
                }
                else if (elec != null)
                {
                    summary = "Electrical due on " + elec.DtNextDue.ToString("d") + ". No current gas certificate";
                }
                return summary;
            }
        }
        #endregion
        
        public PropertyViewModel()
        {
            OKCommand = new Command(OKPressed);
            DeletePropertyCommand = new Command(DeleteProperty);
            TenancyDetailsCommand = new Command(ViewTenancyDetails);
            InsuranceDetailsCommand = new Command(ViewInsuranceDetails);
            MortgageDetailsCommand = new Command(ViewMortgageDetails);
            SafetyCertificateDetailsCommand = new Command(ViewSafetyCertificateDetails);
            PurchaseDate = DateTime.Today;
        }        

        #region commands
        public Command OKCommand { get; }
        public Command DeletePropertyCommand { get; }
        public Command TenancyDetailsCommand { get; }
        public Command InsuranceDetailsCommand { get; }
        public Command MortgageDetailsCommand { get; }
        public Command SafetyCertificateDetailsCommand { get; }

        private void ViewSafetyCertificateDetails(object obj)
        {
            throw new NotImplementedException();
        }

        private void ViewMortgageDetails(object obj)
        {
            throw new NotImplementedException();
        }

        private void ViewTenancyDetails(object obj)
        {
            throw new NotImplementedException();
        }

        private async void ViewInsuranceDetails(object obj)
        {
            InsuranceViewModel ivm = InsuranceViewModel.CreateViewModel(CurrentInsurance);
            await PushAsync(new InsurancePage(ivm));
            InsurancePolicy updated = await ivm.Retval.Task;
            if (updated != null)
            {
                CurrentInsurance = updated;
                OnPropertyChanged(nameof(CurrentInsurance));
                OnPropertyChanged(nameof(InsuranceSummary));
            }
        }

        private async void DeleteProperty(object obj)
        {
            var name = "this property";
            if (Address?.Street1 != null && Address?.Street1.Length > 0)
            {
                name = Address?.Street1;
            }
            bool confirm = await DisplayAlert("Question", "Are you sure you want to delete " + name + "?", "Yes", "No");
            if (!confirm)
                return;

            Retval.SetResult(null);
            await PopAsync();
        }

        protected override async void OKPressed(object obj)
        {
            Address address = AddressViewModel.ValidateAndGetAddress();
            if (address == null)
                return;
            if (!Validate())
                return;

            Property p = ReverseMap();
            p.Address = address;
            Retval.SetResult(p);
            await PopAsync();
        }

        protected override bool Validate()
        {            
            return true;
        }
        #endregion commands

        new public static PropertyViewModel CreateViewModel(Property p)
        {
            PropertyViewModel vm = BaseMappingViewModel<Property, PropertyViewModel>.CreateViewModel(p);
            vm.existingProperty = p != null;
            return vm;
        }
    }
}
