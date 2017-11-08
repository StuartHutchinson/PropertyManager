using AutoMapper;
using PropertyManager.Model;

namespace PropertyManager.ViewModel
{
    class AddressViewModel
    {
        private Address address;

        public string Street1 { get; set; }
        public string Street2 { get; set; }
        public string Town { get; set; }
        public string County { get; set; }
        public string Postcode { get; set; }

        public static AddressViewModel CreateViewModel(Address a)
        {
            AddressViewModel vm;
            if (a == null)
            {
                vm = new AddressViewModel { address = new Address() };
            }
            else
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Address, AddressViewModel>());
                vm = Mapper.Map<AddressViewModel>(a);
            }
            return vm;
        }
    }
}
