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
    public class EkranTasarimDetay : IComplexType
 { 
        public int Id { get; set; }
        public int GrupId { get; set; }
        [Display(Name = "Adı")]
        public string Adi { get; set; }
        [Display(Name = "Kullanıcı")]
        public string GrupAdi { get; set; }
        [Display(Name = "Baş. Tarihi")]
        public DateTime BaslamaTarihi { get; set; }
        [Display(Name = "Son Değiş. Tarihi")]
        public DateTime SonDegisiklikTarihi { get; set; }
        [Display(Name = "Bit. Tarihi")]
        public DateTime? BitisTarihi { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        public bool Checked { get; set; }
        public bool Expanded { get; set; }
        public int RoldeId { get; set; }

        public string SonDegisiklikTarihiString => String.Format("{0:dd/MM/yyyy, hh:mm}", SonDegisiklikTarihi); //{ get; set; }
       

    }
} 