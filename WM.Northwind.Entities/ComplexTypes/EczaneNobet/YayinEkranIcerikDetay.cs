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
    public class YayinEkranIcerikDetay: IComplexType
 { 
        public int Id { get; set; }
        public int EkranIcerikId { get; set; }
        [Display(Name = "İçerik")]
        public string EkranIcerikAdi { get; set; }
        public int Alan { get; set; }
        public int YayinEkranId { get; set; }
        public DateTime BaslamaZamani { get; set; }
        public DateTime? BitisZamani { get; set; }

        [Display(Name = "Başlama Zamanı")]
        public string BaslamaZamaniString => String.Format("{0:dd/MM/yyyy, HH:mm }", BaslamaZamani); //{ get; set; }
        [Display(Name = "Bitiş Zamanı")]
        public string BitisZamaniString => String.Format("{0:dd/MM/yyyy, HH:mm }", BitisZamani); //{ get; set; }

    }
} 