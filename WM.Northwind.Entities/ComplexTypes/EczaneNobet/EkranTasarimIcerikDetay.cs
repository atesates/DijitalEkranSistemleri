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
    public class EkranTasarimIcerikDetay: IComplexType
 { 
        public int Id { get; set; }
        public double BoyutX { get; set; }
        public double BoyutY { get; set; }
        public double KoordinatX { get; set; }
        public double KoordinatY { get; set; }
        public int EkranTasarimId { get; set; }
        public int EkranIcerikId { get; set; }
        public string EkranTasarimAdi { get; set; }
        public string EkranIcerikAdi { get; set; }
        public string Uzanti { get; set; }
        public string Url { get; set; }
        public DateTime EkranTasarimBaslamaTarihi { get; set; }
        public DateTime EkranTasarimSonDegisiklikTarihi { get; set; }

    }
} 