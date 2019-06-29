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
    public class YayinEkranDetay: IComplexType
 { 
        public int Id { get; set; }
        public int EkranId { get; set; }
        public int EkranTasarimId { get; set; }
        public double Enlem { get; set; }
        public double Boylam { get; set; }
        public int CihazId { get; set; }
        public int GrupId { get; set; }
        public int MonitorId { get; set; }
        public int KonumId { get; set; }
        public int CihazDurumId { get; set; }
        [Display(Name = "Baş. Tarihi")]
        public DateTime BaslamaZamani { get; set; }
        [Display(Name = "Bit. Tarihi")]
        public DateTime? BitisZamani { get; set; }
        [Display(Name = "Monitör Adı")]
        public string MonitorAdi { get; set; }
        [Display(Name = "Ekran Tasarım Adı")]
        public string EkranTasarimAdi { get; set; }
        [Display(Name = "Cihaz Seri Nu.")]
        public string CihazSeriNu { get; set; }
        [Display(Name = "Cihaz Durumu")]
        public string CihazDurumAdi { get; set; }
        [Display(Name = "Kullanıcı")]
        public string GrupAdi { get; set; }
        [Display(Name = "Konum")]
        public string KonumAdi { get; set; }
        [Display(Name = "Tas. Baş. Tarihi")]
        public DateTime EkranTasarimBaslamaTarihi { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm}")]
        [Display(Name = "Tas. Değiş. Tarihi")]
        public DateTime EkranTasarimSonDegisiklikTarihi { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy.MM.dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Cihaz Günc. Tarihi")]
        public DateTime CihazSonDegisiklikTarihi { get; set; }
        public string EkranUrl { get; set; }

        [Display(Name = "Cihazı Son Güncelleyen Kullanıcı")]
        public string CihaziSonGuncelleyenUserAdi { get; set; }
        public int CihaziSonGuncelleyenUserId { get; set; }
        [Display(Name = "Tas. Bit.. Tarihi")]
        public DateTime? EkranTasarimBitisTarihi { get; set; }
        public int PingPeriyodu { get; set; }
        public bool Checked { get; set; }
        public bool Expanded { get; set; }

        [Display(Name = "Cihaz Günc. Tarihi")]
        public string CihazSonDegisiklikTarihiString => String.Format("{0:dd/MM/yyyy, HH:mm }", CihazSonDegisiklikTarihi); //{ get; set; }
        [Display(Name = "Tasarım Günc. Tarihi")]
        public string EkranTasarimSonDegisiklikTarihiString => String.Format("{0:dd/MM/yyyy, HH:mm }", EkranTasarimSonDegisiklikTarihi); //{ get; set; }

        [Display(Name = "Başlama Zamanı")]
        public string BaslamaZamaniString => String.Format("{0:dd/MM/yyyy, HH:mm}", BaslamaZamani); //{ get; set; }
        [Display(Name = "Bitiş Zamanı")]
        public string BitisZamaniString => String.Format("{0:dd/MM/yyyy, HH:mm}", BitisZamani); //{ get; set; }
    }
} // This example displays the following output to the console:
  //       d: 6/15/2008
  //       D: Sunday, June 15, 2008
  //       f: Sunday, June 15, 2008 9:15 PM
  //       F: Sunday, June 15, 2008 9:15:07 PM
  //       g: 6/15/2008 9:15 PM
  //       G: 6/15/2008 9:15:07 PM
  //       m: June 15
  //       o: 2008-06-15T21:15:07.0000000
  //       R: Sun, 15 Jun 2008 21:15:07 GMT
  //       s: 2008-06-15T21:15:07
  //       t: 9:15 PM
  //       T: 9:15:07 PM
  //       u: 2008-06-15 21:15:07Z
  //       U: Monday, June 16, 2008 4:15:07 AM
  //       y: June, 2008
  //       
  //       'h:mm:ss.ff t': 9:15:07.00 P
  //       'd MMM yyyy': 15 Jun 2008
  //       'HH:mm:ss.f': 21:15:07.0
  //       'dd MMM HH:mm:ss': 15 Jun 21:15:07
  //       '\Mon\t\h\: M': Month: 6
  //       'HH:mm:ss.ffffzzz': 21:15:07.0000-07:00