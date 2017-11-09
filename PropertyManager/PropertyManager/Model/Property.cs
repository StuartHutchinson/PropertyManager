using Newtonsoft.Json;
using System;
using System.Collections.Generic;

namespace PropertyManager.Model
{
    public class Property
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

        [JsonIgnore]
        public string Name { get { return ToString(); } }
        [JsonIgnore]
        public string Postcode
        {
            get
            {
                var postcode = Address?.Postcode;
                if (postcode is null)
                    postcode = "";
                return postcode;
            }
        }

        public override string ToString()
        {
            return Address.Street1;
        }
    }
}
