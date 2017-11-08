using System;
using Xamarin.Forms;

namespace PropertyManager.Model
{
    class SafetyCertificate
    {
        public enum CertificateType { Gas, Electrical }

        public CertificateType Type { get; set; }
        public DateTime DtChecked { get; set; }
        public DateTime DtNextDue { get; set; }
        public Image Certificate { get; set; }
    }
}
