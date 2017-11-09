using System;

namespace PropertyManager.Model
{
    public class Valuation
    {
        public float ValuationAmount { get; set; }
        public string ValuedBy { get; set; }
        public DateTime DtValuation { get; set; }
        public string Notes { get; set; }
    }
}
