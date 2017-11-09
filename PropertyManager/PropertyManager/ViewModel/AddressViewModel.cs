using AutoMapper;
using PropertyManager.Model;

namespace PropertyManager.ViewModel
{
    class AddressViewModel : BaseMappingViewModel<Address, AddressViewModel>
    {
        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }

        //public static AddressViewModel CreateViewModel(Address a)
        //{
        //    AddressViewModel vm;
        //    if (a == null)
        //    {
        //        vm = new AddressViewModel();
        //    }
        //    else
        //    {
        //        Mapper.Initialize(cfg => cfg.CreateMap<Address, AddressViewModel>());
        //        vm = Mapper.Map<AddressViewModel>(a);
        //    }
        //    return vm;
        //}

        public Address ValidateAndGetAddress()
        {
            if (!Validate())
                return null;
            Mapper.Initialize(cfg => cfg.CreateMap<AddressViewModel, Address>());
            return Mapper.Map<Address>(this);
        }

        protected override bool Validate()
        {
            if (Street1 == null || Street1.Length == 0)
            {
                DisplayValidationError("You must enter a street name");
                return false;
            }
            return true;
        }
    }
}
