using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WM.Core.Entities;

namespace WM.Northwind.Entities.Concrete.EczaneNobet
{
    public class YayinEkran : IEntity
    {
        public int Id { get; set; }
        public int EkranId { get; set; }
        public int EkranTasarimId { get; set; }
        public DateTime BaslamaZamani { get; set; }
        public DateTime? BitisZamani { get; set; }

        public virtual Ekran Ekran { get; set; }
        public virtual EkranTasarim EkranTasarim { get; set; }

        public virtual List<YayinEkranIcerik> YayinEkranIcerikler { get; set; }


    }
}