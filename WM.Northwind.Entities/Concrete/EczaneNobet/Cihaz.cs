using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Core.Entities;
using WM.Northwind.Entities.Concrete.Authorization;

namespace WM.Northwind.Entities.Concrete.EczaneNobet
{
    public class Cihaz : IEntity
    {
        public int Id { get; set; }
        public int GrupId { get; set; }
        public int SonGuncelleyenUserId { get; set; }
        public int CozunurlukId { get; set; }
        public int CihazDurumId { get; set; }
        public int PingPeriyodu { get; set; }
        public string ApiUrl { get; set; }
        public string Marka { get; set; }
        public string Model { get; set; }
        [Display(Name = "Seri Nu.")]
        public string SeriNu { get; set; }
        [Display(Name = "Alım Tarihi")]
        public DateTime AlimTarihi { get; set; }
        [Display(Name = "Başlama Tarihi")]
        public DateTime BaslamaTarihi { get; set; }
        [Display(Name = "Son Gün. Tarihi")]
        public DateTime SonGuncellenmeTarihi { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime? BitisTarihi { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        public string WiFiKullaniciAdi { get; set; }
        public string WiFiParola { get; set; }

        public virtual List<Ekran> Ekranlar { get; set; }
        public virtual Cozunurluk Cozunurluk { get; set; }
        public virtual CihazDurum CihazDurum { get; set; }
        public virtual User User { get; set; }
        public virtual Grup Grup { get; set; }


    }
}