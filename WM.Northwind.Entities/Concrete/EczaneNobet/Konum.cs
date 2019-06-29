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
    public class Konum : IEntity
    {
        public int Id { get; set; }
        public int GrupId { get; set; }
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz..!")]
        public double Enlem { get; set; }
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz..!")]
        public double Boylam { get; set; }
        [Display(Name = "Başlama Tarihi")]
        public DateTime BaslamaTarihi { get; set; }
        [Display(Name = "Bitiş Tarihi")]
        public DateTime? BitisTarihi { get; set; }
        [Display(Name = "Açıklama")]
        public string Aciklama { get; set; }
        public string Adi { get; set; }

        public virtual List<Ekran> Ekranlar { get; set; }
        public virtual Grup Grup { get; set; }

    }
}