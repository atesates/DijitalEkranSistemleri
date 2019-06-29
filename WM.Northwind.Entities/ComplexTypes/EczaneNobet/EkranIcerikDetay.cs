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
    public class EkranIcerikDetay: IComplexType
 { 
        public int Id { get; set; }
        [Display(Name = "Adı")]
        public string Adi { get; set; }
        [Display(Name = "Uzantı")]
        public string Uzanti { get; set; }
        public int RoldeId { get; set; }
        public int GrupId { get; set; }
        public string Url { get; set; }
        public bool Checked { get; set; }
        public bool Expanded { get; set; }
        [Display(Name = "Kullanıcı")]
        public string GrupAdi { get; set; }

        public DateTime SonYayinaBaslamaZamani { get; set; }
    } 
} 