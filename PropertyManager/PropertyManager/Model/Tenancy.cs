using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace PropertyManager.Model
{
    class Tenancy
    {
        public DateTime DtStart { get; set; }
        public DateTime DtEnd { get; set; }
        public float MonthlyRent { get; set; }
        public List<Tenant> Tenants { get; set; }
        public Image Agreement { get; set; }
    }
}
