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
    public class EkranIcerik : IEntity
    {
        public int Id { get; set; }
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz..!")]
        public string Adi { get; set; }
        [Required(ErrorMessage = "{0} alanı boş bırakılamaz..!")]
        public string Uzanti { get; set; }     
        public string Url { get; set; }
        public int GrupId { get; set; }

        public virtual Grup Grup { get; set; }
        public virtual List<EkranTasarimIcerik> EkranTasarimIcerikler { get; set; }
        public virtual List<YayinEkranIcerik> YayinEkranIcerikler { get; set; }

    }
}