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
    public class MonitorDetay : IComplexType
 {
        public int Id { get; set; }
        public int GrupId { get; set; }
        public int CozunurlukId { get; set; }
        [Display(Name = "Çözünürlük")]
        public string CozunurlukAdi { get; set; }
        [Display(Name = "Seri Nu.")]
        public string SeriNu { get; set; }
        [Display(Name = "Alım Tarihi")]
        public DateTime AlimTarihi { get; set; }
        [Display(Name = "Başlama Tarihi")]
        public DateTime BaslamaTarihi { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime? BitisTarihi { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        public string Adi { get; set; }
        public string Marka { get; set; }
        public int BoyutuInc { get; set; }
        public int RoldeId { get; set; }

        [Display(Name = "Kullanıcı")]
        public string GrupAdi { get; set; }
        public int UserdId { get; set; }
    } 
} 