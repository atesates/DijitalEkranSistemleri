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
    public class CihazDetay: IComplexType
 {
        public int Id { get; set; }
        public int CozunurlukId { get; set; }
        public int CihazDurumId { get; set; }
        [Display(Name = "Çözünürlük")]
        public string CozunurlukAdi { get; set; }
        [Display(Name = "Cihaz Durumu")]
        public string CihazDurumAdi { get; set; }
        public string ApiUrl { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        [Display(Name = "Seri Nu.")]
        public string SeriNu { get; set; }
        [Display(Name = "Alım Tarihi")]
        public DateTime AlimTarihi { get; set; }
        [Display(Name = "Başlama Tarihi")]
        public DateTime BaslamaTarihi { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime? BitisTarihi { get; set; }
        [Display(Name = "Son Gün. Tarihi")]
        public DateTime SonGuncellenmeTarihi { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        [Display(Name = "Kullanıcı")]
        public string GrupAdi { get; set; }
        [Display(Name = "Son Güncelleyen Kullanıcı")]
        public string SonGuncelleyenUserAdi { get; set; }
        public int SonGuncelleyenUserId { get; set; }
        public int GrupId { get; set; }
        public int RoldeId { get; set; }
        public int PingPeriyodu { get; set; }
        public string CihazDurumAciklama { get; set; }
        public string WiFiKullaniciAdi { get; set; }
        public string WiFiParola { get; set; }

    }
} 