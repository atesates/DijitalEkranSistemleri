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
    public class EkranDetay: IComplexType
 { 
        public int Id { get; set; }
        public int MonitorId { get; set; }
        public int KonumId { get; set; }
        public int CihazId { get; set; }
        public int GrupId { get; set; }
        public double Enlem { get; set; }
        public double Boylam { get; set; }
        public int CihazDurumId { get; set; }
        public string EkranAdi { get; set; }

        [Display(Name = "Baş. Tarihi")]
        public DateTime BaslamaTarihi { get; set; }
        [Display(Name = "Bit. Tarihi")]
        public DateTime? BitisTarihi { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        public bool AktifMi { get; set; }
        [Display(Name = "Konum")]
        public string KonumAdi { get; set; }
        public string EkranUrl { get; set; }
        [Display(Name = "Monitör Adı")]
        public string MonitorAdi { get; set; }
        [Display(Name = "Ekran Tasarım Adı")]
        public string EkranTasarimAdi { get; set; }
        [Display(Name = "Cihaz Seri Nu.")]
        public string CihazSeriNu { get; set; }
        [Display(Name = "Cihaz Durumu")]
        public string CihazDurumAdi { get; set; }
        [Display(Name = "Monitör Seri Nu.")]
        public string MonitorSeriNu { get; set; }
        [Display(Name = "Kullanıcı")]
        public string GrupAdi { get; set; }
        [Display(Name = "Baş. Tarihi")]
        public DateTime EkranTasarimBaslamaTarihi { get; set; }
        [DisplayFormat(DataFormatString = "{0:dd MMM yyyy HH:mm}")]
        [Display(Name = "Tas. Değiş. Tarihi")]
        public DateTime EkranTasarimSonDegisiklikTarihi { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy.MM.dd}", ApplyFormatInEditMode = true)]
        [Display(Name = "Cihaz Günc. Tarihi")]
        public DateTime CihazSonDegisiklikTarihi { get; set; }

        [Display(Name = "Cihazı Son Güncelleyen Kullanıcı")]
        public string CihaziSonGuncelleyenUserAdi { get; set; }
        public int CihaziSonGuncelleyenUserId { get; set; }
        [Display(Name = "Tas. Bit. Tarihi")]
        public DateTime? EkranTasarimBitisTarihi { get; set; }
        public int PingPeriyodu { get; set; }
        public int RoldeId { get; set; }
        public bool Checked { get; set; }
        public bool Expanded { get; set; }

        public string CihazSonDegisiklikTarihiString => String.Format("{0:dd/MM/yyyy, hh:mm}", CihazSonDegisiklikTarihi); //{ get; set; }
        public string EkranTasarimSonDegisiklikTarihiString => String.Format("{0:dd/MM/yyyy, hh:mm}", EkranTasarimSonDegisiklikTarihi); //{ get; set; }

    }
} 