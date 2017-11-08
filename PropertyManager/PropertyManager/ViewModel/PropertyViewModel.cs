using AutoMapper;
using PropertyManager.Model;
using System;
using System.Collections.Generic;

namespace PropertyManager.ViewModel
{
    class PropertyViewModel
    {
        private Property property { get; set; }

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

        public static PropertyViewModel CreateViewModel(Property p)
        {
            PropertyViewModel vm;
            if (p == null)
            {
                vm = new PropertyViewModel { property = new Property() };
            }
            else
            {
                Mapper.Initialize(cfg => cfg.CreateMap<Property, PropertyViewModel>());
                vm = Mapper.Map<PropertyViewModel>(p);
            }
            return vm;
        }
    }
}
