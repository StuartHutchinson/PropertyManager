using System.Collections.Generic;
using Xamarin.Forms;

namespace PropertyManager.Model
{
    public class Tenant
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Phone { get; set; }
        public bool LeadTenant { get; set; }
        public Image ID { get; set; }
        public Address EndOfTenancyAddress { get; set; }

        public static Tenant GetLeadTenant(List<Tenant> tenants)
        {
            return tenants?.Find(t => t.LeadTenant);
        }
    }
}
