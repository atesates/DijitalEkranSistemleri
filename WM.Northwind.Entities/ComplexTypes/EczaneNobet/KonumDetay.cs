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
    public class KonumDetay : IComplexType
 {
        public int Id { get; set; }
        [Display(Name = "Adı")]
        public string Adi { get; set; }
        public int GrupId { get; set; }
        [Display(Name = "Kullanıcı")]
        public string GrupAdi { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        public double Enlem { get; set; }
        public double Boylam { get; set; }
        public int RoleId { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }

    } 
} 