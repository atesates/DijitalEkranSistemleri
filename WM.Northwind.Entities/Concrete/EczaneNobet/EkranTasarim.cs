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
    public class EkranTasarim : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz..!")]
        [Display(Name = "Adı")]
        public string Adi { get; set; }
        public int GrupId { get; set; }
        public DateTime BaslamaTarihi { get; set; }
        public DateTime? BitisTarihi { get; set; }
        public DateTime SonDegisiklikTarihi { get; set; }
        public string Aciklama { get; set; }

        public virtual Grup Grup { get; set; }
        public virtual List<EkranTasarimIcerik> EkranTasarimIcerikler { get; set; }
        public virtual List<YayinEkran> YayinEkranlar { get; set; }

    }
}