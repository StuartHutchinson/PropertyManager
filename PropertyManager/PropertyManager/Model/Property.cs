using System;
using System.Collections.Generic;

namespace PropertyManager.Model
{
    class Property
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

        public string GetName()
        {
            return Address.Street1;
        }
    }
}
