using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Core.Entities;
using WM.Northwind.Entities.Concrete.EczaneNobet;

namespace WM.Northwind.Entities.ComplexTypes.EczaneNobet
{
    public class EkranTakipDetay : IComplexType
    {
        public int CihazId { get; set; }
        public string CihazUrl { get; set; }
        public string DomainUrl { get; set; }
        //public DateTime TasarimDegisimTarihi { get; set; }
        //public bool Durum { get; set; }
        public int CihazDurumId { get; set; }
        public DateTime SonDegisiklilkTarihi { get; set; }
        public int PingPeriyodu { get; set; }
        public int RoldeId { get; set; }
        public string WifiKullaniciAdi { get; set; }
        public string WifiParola { get; set; }
        public string CihazDurumAciklama { get; set; }
        public string CihazDurumAdi { get; set; }


    }
}
