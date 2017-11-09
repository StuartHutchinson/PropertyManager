using System;

namespace PropertyManager.Model
{
    public class Mortgage
    {
        public string Provider { get; set; }
        public string AccountNo { get; set; }
        public DateTime DtStart { get; set; }
        public DateTime DtEnd { get; set; }
        public float FixedRate { get; set; }
        public DateTime DtFixedRateExpiry { get; set; }
        public float LoanAmount { get; set; }
        public short LTV { get; set; }
        public float LoanRemaining { get; set; }
        public DateTime DtLoanRemaining { get; set; }
        public Valuation Valuation { get; set; }
        public float MonthlyPayment { get; set; }
    }
}
