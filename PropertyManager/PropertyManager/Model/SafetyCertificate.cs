using System;
using System.Collections.Generic;
using System.Linq;
using Xamarin.Forms;

namespace PropertyManager.Model
{
    public class SafetyCertificate
    {
        public enum CertificateType { Gas, Electrical }

        public CertificateType Type { get; set; }
        public DateTime DtChecked { get; set; }
        public DateTime DtNextDue { get; set; }
        public Image Certificate { get; set; }

        public static SafetyCertificate GetLatestGas(List<SafetyCertificate> list)
        {
            if (list == null || list.Count == 0)
            {
                return null;
            }
            var sorted = list.OrderByDescending(cert => cert.DtChecked).ToList();
            return sorted.Find(cert => cert.Type == CertificateType.Gas);
        }

        public static SafetyCertificate GetLatestElectrical(List<SafetyCertificate> list)
        {
            if (list == null || list.Count == 0)
            {
                return null;
            }
            var sorted = list.OrderByDescending(cert => cert.DtChecked).ToList();
            return sorted.Find(cert => cert.Type == CertificateType.Electrical);
        }
    }
}
