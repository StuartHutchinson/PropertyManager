using AutoMapper;
using PropertyManager.Model;
using System;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace PropertyManager.ViewModel
{
    internal class InsuranceViewModel : BaseMappingViewModel<InsurancePolicy, InsuranceViewModel>
    {
        public string Provider { get; set; }
        public string PolicyNo { get; set; }
        public DateTime DtStart { get; set; }
        public DateTime DtEnd { get; set; }
        public float AnnualPrice { get; set; }
        public int BuildingsSumInsured { get; set; }
        public int ContentsSumInsured { get; set; }
        public string Excess { get; set; }

        //public TaskCompletionSource<InsurancePolicy> Retval = new TaskCompletionSource<InsurancePolicy>();

        public Command OKCommand { get; }

        //private async void OKPressed(object obj)
        //{
        //    if (!Validate())
        //        return;

        //    Mapper.Initialize(cfg => cfg.CreateMap<InsuranceViewModel, InsurancePolicy>());
        //    InsurancePolicy policy = Mapper.Map<InsurancePolicy>(this);
        //    Retval.SetResult(policy);
        //    await PopAsync();
        //}
        protected override bool Validate()
        {
            if (Provider.Length == 0)
            {
                DisplayValidationError("You must enter a Provider");
                return false;
            }
            if (PolicyNo.Length == 0)
            {
                DisplayValidationError("You must enter a Policy Number");
                return false;
            }
            return true;
        }

        public InsuranceViewModel()
        {
            OKCommand = new Command(OKPressed);
            DtEnd = DateTime.Today.AddYears(1);
            DtStart = DateTime.Today;
        }

        //public static InsuranceViewModel CreateViewModel(InsurancePolicy policy)
        //{
        //    InsuranceViewModel vm;
        //    if (policy == null)
        //    {
        //        vm = new InsuranceViewModel();
        //    }
        //    else
        //    {
        //        Mapper.Initialize(cfg => cfg.CreateMap<InsurancePolicy, InsuranceViewModel>());
        //        vm = Mapper.Map<InsuranceViewModel>(policy);
        //    }
        //    return vm;
        //}
    }
}
