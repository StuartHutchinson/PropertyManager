using System;

namespace PropertyManager.Model
{
    public class InsurancePolicy
    {
        public string Provider { get; set; }
        public string PolicyNo { get; set; }
        public DateTime DtStart { get; set; }
        public DateTime DtEnd { get; set; }
        public float AnnualPrice { get; set; }
        public int BuildingsSumInsured { get; set; }
        public int ContentsSumInsured { get; set; }
        public string Excess { get; set; }
    }
}
